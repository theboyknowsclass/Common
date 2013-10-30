using System;
using System.Configuration;
using System.Security;
using System.Security.Permissions;
using TheBoyKnowsClass.Common.Desktop.Enumerations;
using TheBoyKnowsClass.Common.Desktop.Operations.Log;

namespace TheBoyKnowsClass.Common.Desktop.Operations.Settings
{
    public abstract class SettingsHelper<T>
        where T : class, new()
    {
        private readonly Configuration _configuration;
        private readonly bool _canSaveAppSettings;
        private readonly LogHelper _logHelper;
        private readonly ApplicationSettingsBase _userSettings;

        protected SettingsHelper(ApplicationSettingsBase userSettings, LogHelper logHelper)
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _canSaveAppSettings = CanSaveConfiguration(_configuration);
            _logHelper = logHelper;
            _userSettings = userSettings;
        }

        protected bool CanSaveAppSettings
        {
            get { return _canSaveAppSettings; }
        }

        protected LogHelper LogHelper
        {
            get 
            { 
                return _logHelper;
            }
        }

        protected Configuration Configuration
        {
            get { return _configuration; }
        }

        private bool CanSaveConfiguration(Configuration configuration)
        {
            var fileIoPermission = new FileIOPermission(FileIOPermissionAccess.Write, configuration.FilePath);

            try
            {
                fileIoPermission.Demand();
                return true;
            }
            catch (SecurityException securityException)
            {
                _logHelper.WriteEntry(string.Format("ServiceViewModel Process does not have access to write to : {0} : {1} {2}", configuration.FilePath, Environment.NewLine, securityException.Message), MessageType.Warning);
                return false;
            }
        }

        private void SaveSettingsToAppConfig()
        {
            _configuration.Save(ConfigurationSaveMode.Modified);
        }

        private void SaveSettingsToUserConfig()
        {
            _userSettings.Save();
        }

        public void SaveSettings()
        {
            if (_canSaveAppSettings)
            {
                SaveSettingsToAppConfig();
            }
            else
            {
                SaveSettingsToUserConfig();
            }
        }

        public virtual T Settings
        {
            get
            {
                return CanSaveAppSettings ? AppConfigSettings : UserConfigSettings;
            }
            set
            {
                if(CanSaveAppSettings)
                {
                    AppConfigSettings = value;
                }
                else
                {
                    UserConfigSettings = value;
                }
            }
        }

        protected abstract T AppConfigSettings{ get; set; }

        protected abstract T UserConfigSettings { get; set; }

    }
}
