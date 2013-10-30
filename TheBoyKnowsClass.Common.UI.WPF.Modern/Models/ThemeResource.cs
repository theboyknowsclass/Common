using System.Windows;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Enumerations;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Models
{
    public class ThemeResource : AppearenceResourceBase
    {
        public ThemeResource(ResourceDictionary resourceDictionary)
        {
            if (resourceDictionary.Contains("ThemeName"))
            {
                Name = resourceDictionary["ThemeName"].ToString();
            }

            Initialise(resourceDictionary);
        }

        public override AppearanceResourceType Type
        {
            get { return AppearanceResourceType.Theme; }
        }
    }
}
