using System.ServiceProcess;
using TheBoyKnowsClass.Services.Common.Models;
using TheBoyKnowsClass.SystemServices.Common.Enumerations;

namespace TheBoyKnowsClass.SystemServices.Common.Models
{
    public class SystemService
    {
        private readonly WindowsServiceController _controller;
        private readonly WindowsSystemServiceInstaller _installer;

        public SystemService(string serviceName, string serviceAssemblyPath)
        {
            _controller = new WindowsServiceController(serviceName);
            _installer = new WindowsSystemServiceInstaller(serviceName, serviceAssemblyPath);
        }

        public string ServiceName 
        {
            get
            {
                return _installer.ServiceName;
            }
        }

        public string ServiceAssemblyPath
        {
            get
            {
                return _installer.ServiceAssemblyPath;
            }
            set
            {
                _installer.ServiceAssemblyPath = value;
                _controller.ServiceAssemblyPath = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return _installer.DisplayName;
            }
            set
            {
                _installer.DisplayName = value;
                _controller.DisplayName = value;
            }
        }

        public string Description
        {
            get
            {
                return _installer.Description;
            }
            set
            {
                _installer.Description = value;
            }
        }

        public ServiceStartMode ServiceStartMode
        {
            get
            {
                return _installer.ServiceStartMode;
            }
            set
            {
                _installer.ServiceStartMode = value;
                _controller.ServiceStartMode = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool InteractWithDesktop 
        {
            get
            {
                return _controller.InteractWithDesktop;
            }
            set
            {
                _controller.InteractWithDesktop = value;
            }
        }

        /// <summary>
        /// Gets the Account the ServiceViewModel runs under
        /// </summary>
        public ServiceAccount Account
        {
            get
            {
                return _installer.Account;
            }
            set
            {
                _installer.Account = value;
                _controller.Account = value;
            }
        }

        public string ServiceUsername
        {
            get
            {
                return _installer.UserName;
            }
            set
            {
                _installer.UserName = value;
                _controller.UserName = value;
            }
        }

        public string ServicePassword
        {
            get
            {
                return _installer.Password;
            }
            set
            {
                _installer.Password = value;
                _controller.Password = value;
            }
        }

        public string[] ServiceDependencies
        {
            get
            {
                return _installer.Dependencies;
            }
            set
            {
                _installer.Dependencies = value;
            }
        }

        public SystemServiceStatus SystemServiceStatus
        {
            get
            {
                return _controller.GetStatus();
            }
        }

        public bool IsInstalled
        {
            get
            {
                return _controller.GetStatus() != SystemServiceStatus.NotInstalled;
            }
        }

        public void Install()
        {
            _installer.Install();
            _controller.Refresh();
        }

        public void Uninstall()
        {
            _installer.Uninstall();
            _controller.Refresh();
        }

        public void Stop()
        {
            _controller.Stop();
            _controller.Refresh();
        }

        public void Start()
        {
            _controller.Start();
            _controller.Refresh();
        }
    }
}
