using System;
using System.Collections.Generic;
using System.Text;

namespace Qsu.Objects
{
    public class ReturnValue : IObject
    {
        public IObject Value;

        public ReturnValue(IObject value) => Value = value;
        public string Inspect() => Value.Inspect();
        public ObjectType Type() => ObjectType.RETURN_VALUE;
    }
}
