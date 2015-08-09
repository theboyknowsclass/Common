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

            return default(T);
        }

        public static T? GetEnumWithDescription<T>(string description)
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("GetEnumWithDescription<T> can only be called for types derived from System.Enum", "T");
            }

            foreach (T enumerationValue in GetValues<T>())
            {
                if(enumerationValue.GetEnumDescription() == description)
                {
                    return enumerationValue;
                }
            }

            return null;
        }

        public static T[] GetValues<T>() where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("GetValues<T> can only be called for types derived from System.Enum", "T");
            }
            return (T[])Enum.GetValues(typeof(T));
        }

        public static string GetEnumDescription(this Enum e)
        {
            DescriptionAttribute descriptionAttribute = e.GetEnumAttribute<DescriptionAttribute>();

            return descriptionAttribute.Description;
        }

        public static string GetEnumDescription<T>(this T e) where T : struct
        {
            var enumT = e as Enum;

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("GetEnumDescription<T> can only be called for types derived from System.Enum", "T");
            }
            
            return GetEnumDescription(enumT);
        }

    }
}
