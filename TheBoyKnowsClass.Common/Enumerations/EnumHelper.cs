using System;
using System.Reflection;
using TheBoyKnowsClass.Common.Attributes;

namespace TheBoyKnowsClass.Common.Enumerations
{
    public static class EnumHelper
    {
        public static T GetEnumAttribute<T>(this Enum e)
        where T : Attribute
        {
            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

            var enumAttributes = (T[])fieldInfo.GetCustomAttributes(typeof(T), false);

            if (enumAttributes.Length > 0)
            {
                return enumAttributes[0];
            }

            return null;
        }

        public static string GetEnumDescription(this Enum e)
        {
            DescriptionAttribute descriptionAttribute = e.GetEnumAttribute<DescriptionAttribute>();

            return descriptionAttribute.Description;
        }

    }
}
