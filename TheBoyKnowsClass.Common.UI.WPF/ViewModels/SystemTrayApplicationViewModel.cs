using System.Drawing;
using TheBoyKnowsClass.Common.UI.ViewModels;

namespace TheBoyKnowsClass.Common.UI.WPF.ViewModels
{
    public class SystemTrayApplicationViewModel : ViewModelBase
    {
        private bool _minimiseOnClose;
        private bool _minimiseToSystemTray = true;
        private Icon _systemTrayIcon;

        public SystemTrayApplicationViewModel()
        {
            RaisePropertyChanged("MinimiseOnClose");
        }

        public bool MinimiseOnClose
        {
            get { return _minimiseOnClose; }
            set 
            { 
                _minimiseOnClose = value;
                RaisePropertyChanged("MinimiseOnClose");
            }
        }

        public bool MinimiseToSystemTray
        {
            get { return _minimiseToSystemTray; }
            set
            {
                _minimiseToSystemTray = value;
                RaisePropertyChanged("MinimiseToSystemTray");
            }
        }

        public Icon Icon
        {
            get { return _systemTrayIcon; }
            set
            {
                _systemTrayIcon = value;
                RaisePropertyChanged("Icon");
            }
        }
    }
}
