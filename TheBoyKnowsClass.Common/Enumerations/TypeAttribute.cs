using System;

namespace TheBoyKnowsClass.Common.Enumerations
{
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
    }
}
