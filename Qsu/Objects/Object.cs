using System;

namespace Qsu.Objects
{
    public interface IObject
    {
        public ObjectType Type();
        public string Inspect();
    }
    public enum ObjectType
    {
        INTEGER,
        BOOLEAN,
        NULL,
        RETURN_VALUE,
    }
}
