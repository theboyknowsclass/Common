using System;
using System.Windows;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Enumerations;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Models
{
    public abstract class AppearenceResourceBase : IEquatable<AppearenceResourceBase>
    {
        protected void Initialise(ResourceDictionary resourceDictionary)
        {
            URI = resourceDictionary.Source;

            if (resourceDictionary.Contains("SortOrder"))
            {
                SortOrder = (Int16)resourceDictionary["SortOrder"];
            }
        }

        public abstract AppearanceResourceType Type { get; }
        public Uri URI { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }

        public void Apply()
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;

            ResourceDictionary currentDictionary;

            switch (Type)
            {
                case AppearanceResourceType.Theme:
                    currentDictionary = AppearanceManager.GetCurrentThemeDictionary();
                    break;
                case AppearanceResourceType.Accent:
                    currentDictionary = AppearanceManager.GetCurrentAccentDictionary();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var newDictionary = new ResourceDictionary { Source = URI };
            
            dictionaries.Add(newDictionary);
            dictionaries.Remove(currentDictionary);
        }

        public bool Equals(AppearenceResourceBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(URI.ToString().ToLower(), other.URI.ToString().ToLower());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((AppearenceResourceBase) obj);
        }

        public override int GetHashCode()
        {
            return (URI != null ? URI.ToString().ToLower().GetHashCode() : 0);
        }

    }
}
