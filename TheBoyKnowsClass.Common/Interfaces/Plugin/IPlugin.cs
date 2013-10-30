using System;

namespace TheBoyKnowsClass.Common.Interfaces.Plugin
{
    /// <summary>
    /// This is the interface to implement for Plugins
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Returns the Name of the Plugin
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns the Version of the Plugin
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Returns the Author of the Plugin
        /// </summary>
        string Author { get; }
    }
}
