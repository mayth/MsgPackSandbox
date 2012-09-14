using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace MsgPackSandbox
{
    abstract class Node : IEquatable<Node>
    {
        #region Factory
        public static Node CreateArrayNode(IEnumerable<Node> source)
        {
            return new ArrayNode(source);
        }

        public static Node CreateMapNode(IDictionary<Node, Node> source)
        {
            return new MapNode(source);
        }

        public static Node CreateNilNode()
        {
            return new NilNode();
        }

        public static Node CreateValueNode(object value)
        {
            return CreateValueNode(value, value.GetType());
        }

        public static Node CreateValueNode(object value, Type underlyingType)
        {
            return new ValueNode(value, underlyingType);
        }
        #endregion

        public static Node Parse(MsgPack.MessagePackObject obj)
        {
            if (obj.IsArray)
            {
                var array = new List<Node>();
                var src = obj.AsList();
                foreach (var item in src)
                    array.Add(Parse(item));
                return Node.CreateArrayNode(array);
            }
            else if (obj.IsMap)
            {
                var map = new Dictionary<Node, Node>();
                var src = obj.AsDictionary();
                foreach (var kv in src)
                    map.Add(Parse(kv.Key), Parse(kv.Value));
                return Node.CreateMapNode(map);
            }
            else if (obj.IsNil)
            {
                return Node.CreateNilNode();
            }
            else
            {
                if (obj.UnderlyingType != typeof(string))
                    return Node.CreateValueNode(obj.ToObject(), obj.UnderlyingType);
                else
                    return Node.CreateValueNode(Encoding.Unicode.GetString(obj.AsBinary()), typeof(string));
            }
        }

        abstract public bool Equals(Node other);
    }
}
