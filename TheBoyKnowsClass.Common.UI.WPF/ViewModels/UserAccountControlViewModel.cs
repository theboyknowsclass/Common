using System.Windows.Media.Imaging;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.UI.ViewModels;
using TheBoyKnowsClass.Common.UI.WPF.Models;

namespace TheBoyKnowsClass.Common.UI.WPF.ViewModels
{
    public class UserAccountControlViewModel : ViewModelBase
    {
        public UserAccountControlViewModel()
        {
            RestartElevatedCommand = new DelegateCommand(RestartElevated, CanRestartElevated);
            RaisePropertyChanged("IsProcessAdmin");
        }

        public bool IsProcessAdmin
        {
            get
            {
                return UserAccountContoller.IsProcessAdmin;
            }
        }

        public BitmapSource Icon
        {
            get
            {
                return UserAccountContoller.GetShieldBitmap();
            }
        }

        public DelegateCommand RestartElevatedCommand { get; set; }

        private bool _isRestarting;

        private void RestartElevated()
        {
            _isRestarting = true;
            RestartElevatedCommand.RaiseCanExecuteChanged();
            UserAccountContoller.RestartElevated();
            _isRestarting = false;
            RestartElevatedCommand.RaiseCanExecuteChanged();
            RaisePropertyChanged("IsProcessAdmin");
        }

        private bool CanRestartElevated()
        {
            return !(_isRestarting || IsProcessAdmin);
        }

    }
}
