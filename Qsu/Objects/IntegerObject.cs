using System;
using System.Collections.Generic;
using System.Text;

namespace Qsu.Objects
{
    public class IntegerObject : IObject
    {
        public int Value;

        public IntegerObject(int value) => Value = value;

        public ObjectType Type() => ObjectType.INTEGER;

        public string Inspect() => Value.ToString();
    }
}
