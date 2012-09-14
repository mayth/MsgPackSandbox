using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgPackSandbox
{
    class MapNodeEqualityComparer : IEqualityComparer<MapNode>
    {
        public bool Equals(MapNode x, MapNode y)
        {
            return x
                .Zip(y, (a, b) => Tuple.Create(Tuple.Create(a.Key, b.Key), Tuple.Create(a.Value, b.Value)))
                .All(t => t.Item1.Item1 == t.Item1.Item2 && t.Item2.Item1 == t.Item2.Item2);
        }

        public int GetHashCode(MapNode obj)
        {
            return obj.GetHashCode();
        }
    }
}
