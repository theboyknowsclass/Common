using System;

namespace TheBoyKnowsClass.Common.Attributes
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
