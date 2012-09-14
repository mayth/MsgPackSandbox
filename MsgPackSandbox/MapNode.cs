using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgPackSandbox
{
    class MapNode : Node, IReadOnlyDictionary<Node, Node>
    {
        readonly IReadOnlyDictionary<Node, Node> _map;

        public MapNode(IDictionary<Node, Node> source)
        {
            _map = new Dictionary<Node, Node>(source);
        }

        public bool ContainsKey(Node key)
        {
            return _map.ContainsKey(key);
        }

        public IEnumerable<Node> Keys
        {
            get { return _map.Keys; }
        }

        public bool TryGetValue(Node key, out Node value)
        {
            return _map.TryGetValue(key, out value);
        }

        public IEnumerable<Node> Values
        {
            get { return _map.Values; }
        }

        public Node this[Node key]
        {
            get { return _map[key]; }
        }

        public int Count
        {
            get { return _map.Count; }
        }

        public IEnumerator<KeyValuePair<Node, Node>> GetEnumerator()
        {
            return _map.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)_map).GetEnumerator();
        }

        public override bool Equals(Node other)
        {
            var node = other as MapNode;
            if (node == null)
                return false;
            return this
                .Zip(node, (a, b) => Tuple.Create(Tuple.Create(a.Key, b.Key), Tuple.Create(a.Value, b.Value)))
                .All(t => t.Item1.Item1 == t.Item1.Item2 && t.Item2.Item1 == t.Item2.Item2);
        }
    }
}
