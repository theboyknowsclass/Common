using System;
using System.Windows;
using System.Windows.Forms;
using TheBoyKnowsClass.Common.UI.WPF.ViewModels;

namespace TheBoyKnowsClass.Common.UI.WPF.Controls
{
    public class SystemTrayApplicationWindow : Window
    {
        private SystemTrayApplicationViewModel _viewModel;
        private NotifyIcon _notifyIcon;

        public void Initialise(SystemTrayApplicationViewModel viewModel)
        {
            _viewModel = viewModel;

            _notifyIcon = new NotifyIcon { Icon = viewModel.Icon, Visible = viewModel.MinimiseToSystemTray };
            _notifyIcon.DoubleClick += SystemTrayIconDoubleClicked;
        }

        private void SystemTrayIconDoubleClicked(object sender, EventArgs e)
        {
            Show();
            WindowState = WindowState.Normal;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (_viewModel.MinimiseOnClose)
            {
                e.Cancel = true;
                WindowState = WindowState.Minimized;
            }

            if (!e.Cancel)
            {
                _notifyIcon.Visible = false;
            }

            base.OnClosing(e);
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized && _viewModel.MinimiseToSystemTray)
            {
                Hide();
                _notifyIcon.Visible = true;
            }

            base.OnStateChanged(e);
        }
    }
}
