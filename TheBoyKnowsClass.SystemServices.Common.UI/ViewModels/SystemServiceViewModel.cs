using System.ServiceProcess;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.Enumerations;
using TheBoyKnowsClass.Common.UI.ViewModels;
using TheBoyKnowsClass.SystemServices.Common.Enumerations;
using TheBoyKnowsClass.SystemServices.Common.Models;

namespace TheBoyKnowsClass.SystemServices.Common.UI.ViewModels
{
    public class SystemServiceViewModel : ViewModelBase
    {
        private SystemService _service;

        public SystemServiceViewModel()
        {
            InstallCommand = new DelegateCommand(Install,CanInstall);
            UninstallCommand = new DelegateCommand(Uninstall, CanUninstall);
            StartCommand = new DelegateCommand(Start, CanStart);
            StopCommand = new DelegateCommand(Stop, CanStop);
        }

        public SystemServiceViewModel(SystemService service)
            : this()
        {
            Service = service;
        }

        public SystemService Service
        {
            get
            {
                return _service;
            }
            set
            {
                _service = value;
                RaisePropertyChanged("ServiceName");
                RaisePropertyChanged("ServiceAssemblyPath");
                RaisePropertyChanged("DisplayName");
                RaisePropertyChanged("Description");
                RaisePropertyChanged("ServiceStartMode");
                RaisePropertyChanged("Account");
                RaisePropertyChanged("ServiceUsername");
                RaisePropertyChanged("ServicePassword");
                RaisePropertyChanged("ServiceStatus");
                RaisePropertyChanged("InteractWithDesktop");
                InstallCommand.RaiseCanExecuteChanged();
                UninstallCommand.RaiseCanExecuteChanged();
                StartCommand.RaiseCanExecuteChanged();
                StopCommand.RaiseCanExecuteChanged();
            }

        }

        public string ServiceName
        {
            get
            {
                return _service.ServiceName;
            }
        }

        public string ServiceAssemblyPath
        {
            get
            {
                return _service.ServiceAssemblyPath;
            }
            set
            {
                _service.ServiceAssemblyPath = value;
                RaisePropertyChanged("ServiceAssemblyPath");
            }
        }

        public string DisplayName
        {
            get
            {
                return _service.DisplayName;
            }
            set
            {
                _service.DisplayName = value;
                RaisePropertyChanged("DisplayName");
            }
        }

        public string Description
        {
            get
            {
                return _service.Description;
            }
            set
            {
                _service.Description = value;
                RaisePropertyChanged("Description");
            }
        }

        public ServiceStartMode ServiceStartMode
        {
            get
            {
                return _service.ServiceStartMode;
            }
            set
            {
                _service.ServiceStartMode = value;
                RaisePropertyChanged("ServiceStartMode");
            }
        }

        public bool InteractWithDesktop
        {
            get
            {
                return _service.InteractWithDesktop;
            }
            set
            {
                _service.InteractWithDesktop = value;
                RaisePropertyChanged("InteractWithDesktop");
            }
        }

        public ServiceAccount Account
        {
            get
            {
                return _service.Account;
            }
            set
            {
                _service.Account = value;
                RaisePropertyChanged("Account");

            }
        }

        public string ServiceUsername
        {
            get
            {
                return _service.ServiceUsername;
            }
            set
            {
                _service.ServiceUsername = value;
                RaisePropertyChanged("ServiceUsername");

            }
        }

        public string ServicePassword
        {
            get
            {
                return _service.ServicePassword;
            }
            set
            {
                _service.ServicePassword = value;
                RaisePropertyChanged("ServicePassword");
            }
        }

        public string ServiceStatus
        {
            get
            {
                return _service.SystemServiceStatus.GetEnumDescription();
            }
        }

        public bool IsWorking
        {
            get
            {
                return _isInstalling || _isUninstalling || _isStarting || _isStopping;
            }
        }

        #region Commands

        private bool _isInstalling;
        private bool _isUninstalling;

        public DelegateCommand InstallCommand { get; set; }

        private void Install()
        {
            _isInstalling = true;
            RefreshCommands();
            _service.Install();
            _isInstalling = false;
            RefreshCommands();
        }

        private bool CanInstall()
        {
            return !(_service.IsInstalled || _isInstalling || _isUninstalling);
        }

        public DelegateCommand UninstallCommand { get; set; }

        private void Uninstall()
        {
            _isUninstalling = true;
            RefreshCommands();
            _service.Uninstall();
            _isUninstalling = false;
            RefreshCommands();
        }

        private bool CanUninstall()
        {
            return _service.IsInstalled && !(_isUninstalling);
        }

        private bool _isStarting;
        private bool _isStopping;

        public DelegateCommand StartCommand { get; set; }

        private void Start()
        {
            _isStarting = true;
            RefreshCommands();
            _service.Start();
            _isStarting = false;
            RefreshCommands();
        }

        private bool CanStart()
        {
            return _service.SystemServiceStatus == SystemServiceStatus.Stopped && !(_isStarting);
        }

        public DelegateCommand StopCommand { get; set; }

        private void Stop()
        {
            _isStopping = true;
            RefreshCommands();
            _service.Stop();
            _isStopping = false;
            RefreshCommands();
        }

        private bool CanStop()
        {
            return _service.SystemServiceStatus == SystemServiceStatus.Running && !(_isStopping);
        }

        private void RefreshCommands()
        {
            InstallCommand.RaiseCanExecuteChanged();
            UninstallCommand.RaiseCanExecuteChanged();
            StartCommand.RaiseCanExecuteChanged();
            StopCommand.RaiseCanExecuteChanged();
            RaisePropertyChanged("ServiceStatus");
            RaisePropertyChanged("IsWorking");
        }

        #endregion   
    }
}
