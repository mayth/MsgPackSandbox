using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgPackSandbox
{
    class ArrayNode : Node, IReadOnlyList<Node>
    {
        readonly IList<Node> _array;

        public ArrayNode(IEnumerable<Node> source)
        {
            _array = new List<Node>(source);
        }

        public Node this[int index]
        {
            get { return _array[index]; }
        }

        public int Count
        {
            get { return _array.Count; }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return _array.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)_array).GetEnumerator();
        }

        public override bool Equals(Node other)
        {
            var array = other as ArrayNode;
            if (array == null)
                return false;
            return array.SequenceEqual(array);
        }
    }
}
