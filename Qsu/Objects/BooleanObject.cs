using System;
using System.Collections.Generic;
using System.Text;

namespace Qsu.Objects
{
    public class BooleanObject : IObject
    {
        public bool Value;

        public BooleanObject(bool value) => Value = value;

        public ObjectType Type() => ObjectType.BOOLEAN;

        public string Inspect() => Value.ToString();
    }
}
