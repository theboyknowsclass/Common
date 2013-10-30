using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TheBoyKnowsClass.Common.Interfaces.Plugin;

namespace TheBoyKnowsClass.Common.Desktop.Models.Plugin
{
    public class PluginLoader<T>
    where T : IPlugin
    {
        private readonly Dictionary<string,T> _plugins;

        public PluginLoader()
        {
            _plugins = new Dictionary<string, T>();
        }

        public void LoadPlugins(string path)
        {
            foreach (string filename in Directory.GetFiles(path, "*.dll"))
            {
                LoadPlugin(filename);
            }
        }

        public void LoadPlugin(string fileName)
        {
            Assembly assembly = Assembly.LoadFile(fileName);
            foreach (Type assemblyType in assembly.GetTypes())
            {
                if (assemblyType.GetInterface(typeof(T).Name) != null)
                {
                    var plugin = (T)Activator.CreateInstance(assemblyType);
                    Register(plugin);
                }
            }
        }

        private void Register(T plugin)
        {
            _plugins.Add(plugin.GetType().ToString(), plugin);
        }

        public void UnRegister(T plugin)
        {
            _plugins.Remove(plugin.GetType().ToString());
        }

        public T GetPlugin(string typeName)
        {
            return _plugins[typeName];
        }

    }
}
