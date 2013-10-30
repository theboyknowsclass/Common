using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration.Install;
using System.ServiceProcess;

namespace TheBoyKnowsClass.SystemServices.Common.Models
{
    public class WindowsSystemServiceInstaller
    {
        private readonly ServiceInstaller _serviceInstaller;
        private readonly ServiceProcessInstaller _serviceProcessInstaller;

        public WindowsSystemServiceInstaller(string serviceName, string assemblyPath)
        {
            _serviceInstaller = new ServiceInstaller();
            ServiceName = serviceName;
            _serviceProcessInstaller = new ServiceProcessInstaller();
            _serviceInstaller.Parent = _serviceProcessInstaller;
            ServiceAssemblyPath = assemblyPath;
        }

        public ServiceStartMode ServiceStartMode
        {
            get
            {
                return _serviceInstaller.StartType;
            }
            set
            {
                _serviceInstaller.StartType = value;
            }
        }

        public string ServiceName
        {
            get
            {
                return _serviceInstaller.ServiceName;
            }
            set
            {
                _serviceInstaller.ServiceName = value;
            }
        }

        public string ServiceAssemblyPath 
        { 
            get; set;
        }

        public string DisplayName
        {
            get
            {
                return _serviceInstaller.DisplayName;
            }
            set
            {
                _serviceInstaller.DisplayName = value;
            }
        }

        public string Description
        {
            get
            {
                return _serviceInstaller.Description;
            }
            set
            {
                _serviceInstaller.Description = value;
            }
        }

        public ServiceAccount Account
        {
            get
            {
                return _serviceProcessInstaller.Account;
            }
            set
            {
                _serviceProcessInstaller.Account = value;
            }
        }

        public string UserName
        {
            get
            {
                return _serviceProcessInstaller.Username;
            }
            set
            {
                _serviceProcessInstaller.Username = value;
            }
        }


        public string Password
        {
            get
            {
                return _serviceProcessInstaller.Password;
            }
            set
            {
                _serviceProcessInstaller.Password = value;
            }
        }

        public string[] Dependencies
        {
            get
            {
                return _serviceInstaller.ServicesDependedOn;
            }
            set
            {
                _serviceInstaller.ServicesDependedOn = value;
            }
        }

        public void Install()
        {
            SetInstallContext();
            var state = new ListDictionary();
            _serviceInstaller.Install(state);
        }

        public void Uninstall()
        {
            SetInstallContext();
            _serviceInstaller.Uninstall(null); 
        }

        private void SetInstallContext()
        {
            _serviceInstaller.Context = new InstallContext("", new[] { String.Format(@"/assemblypath={0}", @ServiceAssemblyPath) });
        }
    }
}
