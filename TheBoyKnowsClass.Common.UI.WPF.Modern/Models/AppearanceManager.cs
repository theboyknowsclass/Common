using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Models
{
    public static class AppearanceManager
    {
        public static ResourceDictionary GetCurrentThemeDictionary()
        {
            return GetResourceDictionary("ThemeName");
        }

        public static ResourceDictionary GetCurrentAccentDictionary()
        {
            return GetResourceDictionary("AccentName");
        }

        private static ResourceDictionary GetResourceDictionary(string identifier)
        {
            return (from d in Application.Current.Resources.MergedDictionaries
                    where d.Contains(identifier) 
                    select d).FirstOrDefault();
        }

        public static IEnumerable<ThemeResource> GetThemes()
        {
            IEnumerable<Uri> rv = GetAppearanceResources(@"^themes/(?<theme>\w+)\.baml");

            var themes = new List<ThemeResource>();

            foreach (var uri in rv)
            {
                var resourceDictionary = new ResourceDictionary {Source = uri};
                if (resourceDictionary.Contains("ThemeName"))
                {
                    themes.Add(new ThemeResource(resourceDictionary));
                }
            }

            return themes;
        }

        public static IEnumerable<AccentResource> GetAccents()
        {
            IEnumerable<Uri> rv = GetAppearanceResources(@"^accents/(?<accentgroup>\w+)/(?<accent>\w+)\.baml");

            return from r in rv select new AccentResource(new ResourceDictionary { Source = r});
        }

        private static IEnumerable<Uri> GetAppearanceResources(string regexPattern)
        {
            var appearanceManagerAssembly = Assembly.GetAssembly(typeof (AppearanceManager));
            var executingAssembly = Assembly.GetExecutingAssembly();

            IEnumerable<Uri> rv = GetAppearanceResources(appearanceManagerAssembly, regexPattern);

            if (appearanceManagerAssembly.GetName().Name != executingAssembly.GetName().Name)
            {
                rv = rv.Union(GetAppearanceResources(executingAssembly, regexPattern));
            }

            return rv;
        }

        private static IEnumerable<Uri> GetAppearanceResources(Assembly assembly, string regexPattern)
        {
            string assemblyName = assembly.GetName().Name;
            string executingAssembly = Assembly.GetEntryAssembly().GetName().Name;
            string assemblyPart = "";

            if (executingAssembly != assemblyName)
            {
                assemblyPart = string.Format(@"{0};component/",assemblyName);
            }
            
            var searchTerm = new Regex(regexPattern);

            var resourcesName = assemblyName + ".g";
            var manager = new System.Resources.ResourceManager(resourcesName, assembly);
            var resourceSet = manager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            return
                from entry in resourceSet.OfType<DictionaryEntry>()
                let fileName = (string) entry.Key
                let match = searchTerm.Match(fileName)
                where fileName.EndsWith(".baml") && match.Success
                select new Uri(string.Format(@"pack://application:,,,/{0}{1}", assemblyPart, fileName.Replace(".baml", ".xaml")), UriKind.Absolute);
        }
    }
}
