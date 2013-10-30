using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Enumerations;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Models
{
    public class AccentResource : AppearenceResourceBase
    {
        public AccentResource(ResourceDictionary resourceDictionary)
        {
            if (resourceDictionary.Contains("AccentName"))
            {
                Name = resourceDictionary["AccentName"].ToString();
            }

            if (resourceDictionary.Contains("AccentColor"))
            {
                AccentColor = FromHex(resourceDictionary["AccentColor"].ToString());
            }

            if (resourceDictionary.Contains("AccentGroup"))
            {
                AccentGroup = resourceDictionary["AccentGroup"].ToString();
            }

            Initialise(resourceDictionary);
        }

        public override AppearanceResourceType Type
        {
            get { return AppearanceResourceType.Accent;}
        }

        public Color AccentColor { get; set; }

        public string AccentGroup { get; set; }

        private static Color FromHex(string hexValue)
        {
            byte a, r, g, b;

            if (hexValue.Length == 7)
            {
                a = 255;
                r = byte.Parse(hexValue.Substring(1, 2), NumberStyles.AllowHexSpecifier);
                g = byte.Parse(hexValue.Substring(3, 2), NumberStyles.AllowHexSpecifier);
                b = byte.Parse(hexValue.Substring(5, 2), NumberStyles.AllowHexSpecifier);
            }
            else if (hexValue.Length == 9)
            {
                a = byte.Parse(hexValue.Substring(1, 2), NumberStyles.AllowHexSpecifier);
                r = byte.Parse(hexValue.Substring(3, 2), NumberStyles.AllowHexSpecifier);
                g = byte.Parse(hexValue.Substring(5, 2), NumberStyles.AllowHexSpecifier);
                b = byte.Parse(hexValue.Substring(7, 2), NumberStyles.AllowHexSpecifier);
            }
            else
            {
                throw new FormatException("Not a valid hex format");
            }

            return Color.FromArgb(a, r, g, b);
        }
    }
}
