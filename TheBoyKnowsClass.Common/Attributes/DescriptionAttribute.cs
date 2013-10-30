using System;

namespace TheBoyKnowsClass.Common.Attributes
{
    public class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
