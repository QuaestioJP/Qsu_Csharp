using System;
using System.Collections.Generic;
using System.Text;

namespace Qsu.Objects
{
    public class NullObject : IObject
    {
        public ObjectType Type() => ObjectType.NULL;

        public string Inspect() => "null";
    }
}
