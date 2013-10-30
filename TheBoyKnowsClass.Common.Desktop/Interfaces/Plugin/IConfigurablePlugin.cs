namespace TheBoyKnowsClass.Common.Interfaces.Plugin
{
    /// <summary>
    /// This is the interface to implement for Plugins that can be configured
    /// </summary>
    public interface IConfigurablePlugin : IPlugin
    {
        /// <summary>
        /// Returns the current settings for the Plugin
        /// </summary>
        /// <returns>a Settings object</returns>
        object GetSettings();

        /// <summary>
        /// Sets the settings for the Plugin
        /// </summary>
        /// <param name="settings">a Settings object</param>
        /// <returns>Success</returns>
        bool SetSettings(object settings);

        /// <summary>
        /// Displays a Config screen with the specified Settings
        /// </summary>
        /// <param name="settings"></param>
        void DisplayConfig(ref object settings);
    }
}
