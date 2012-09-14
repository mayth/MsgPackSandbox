using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgPackSandbox
{
    class NilNode : Node
    {
        public override bool Equals(Node other)
        {
            return other is NilNode;
        }
    }
}
