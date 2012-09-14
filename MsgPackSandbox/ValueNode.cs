using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsgPackSandbox
{
    class ValueNode : Node
    {
        readonly object _value;
        readonly Type _underlyingType;

        public object Value
        {
            get
            {
                return _value;
            }
        }

        public Type UnderlyingType
        {
            get
            {
                return _underlyingType;
            }
        }

        public ValueNode(object value, Type underlyingType)
        {
            _value = value;
            _underlyingType = underlyingType;
        }

        public ValueNode(object value) : this(value, value.GetType()) { }

        public override bool Equals(Node other)
        {
            var node = other as ValueNode;
            if (node == null)
                return false;
            return this.Value == node.Value;
        }

        public override string ToString()
        {
            return Value.ToString() + "(" + UnderlyingType.Name + ")";
        }
    }
}
