using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.Models;
using TheBoyKnowsClass.Common.UI.ViewModels;
using TheBoyKnowsClass.Common.UI.WPF.Modern.Enumerations;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.ViewModels
{
    public class NavigationManagerViewModel : ViewModelBase
    {
        private Frame _frame;
        private Uri _settingsUri;

        public static NavigationManagerViewModel Instance
        {
            get { return InstanceCreator<NavigationManagerViewModel>.Instance; }
        }

        public NavigationManagerViewModel()
        {
            if (IsInDebug)
            {
                _settingsUri = new Uri("pack://application:,,,/Pages/Settings.xaml");
            }

            GoBackCommand = new DelegateCommand(GoBack, CanExecuteGoBack);
            NavigateCommand = new DelegateCommand<Uri>(Navigate, CanExecuteNavigate);
            ShowSettingsCommand = new DelegateCommand(ShowSettings, CanExecuteShowSettings);
        }

        #region Commands

        public DelegateCommand<Uri> NavigateCommand { get; private set;}

        private void Navigate(Uri uri)
        {
            if (_frame != null)
            {
                _frame.Navigate(uri, SlideDirection.RightToLeft);
            }
        }

        private bool CanExecuteNavigate(Uri uri)
        {
            return _frame != null && (_frame.CurrentSource == null || _frame.CurrentSource != uri);
        }


        public DelegateCommand GoBackCommand { get; private set;}

        private bool CanExecuteGoBack()
        {
            return CanGoBack;
        }

        public bool CanGoBack
        {
            get
            {
                return _frame != null && _frame.CanGoBack;
            }
        }

        private void GoBack()
        {
            if (_frame != null)
            {
                _frame.GoBack();
            }
        }

        public DelegateCommand ShowSettingsCommand { get; private set; }

        private bool CanExecuteShowSettings()
        {
            return _settingsUri != null && CanExecuteNavigate(_settingsUri);
        }

        private void ShowSettings()
        {
            if (_frame != null && _settingsUri != null)
            {
                Navigate(_settingsUri);
            }
        }

        #endregion

        public void RegisterNavigationFrame(Frame frame)
        {
            if (_frame != null)
            {
                _frame.Navigated -= OnNavigated;
            }

            _frame = frame;
            _frame.Navigated += OnNavigated;
            RaisePropertyChanged("IsNavigable");
            ShowSettingsCommand.RaiseCanExecuteChanged();
            NavigateCommand.RaiseCanExecuteChanged();
            GoBackCommand.RaiseCanExecuteChanged();
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            ShowSettingsCommand.RaiseCanExecuteChanged();
            NavigateCommand.RaiseCanExecuteChanged();
            GoBackCommand.RaiseCanExecuteChanged();
            RaisePropertyChanged("CanGoBack");
        }

        public bool IsNavigable
        {
            get
            {
                return _frame != null;
            }
        }

        public Uri SettingsUri
        {
            get
            {
                return _settingsUri;
            }
            set
            {
                _settingsUri = value;
            }
        }

    }
}
