using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.UI.ViewModels;
using TheBoyKnowsClass.Common.UI.WPF.Enumerations;

namespace TheBoyKnowsClass.Common.UI.WPF.ViewModels
{
    public class MessageBoxViewModel : ViewModelBase
    {
        private string _title;
        private string _message;
        private bool _isYesVisible;
        private bool _isNoVisible;
        private bool _isOKVisible;
        private bool _isCancelVisible;
        private bool _isVisible;
        private bool _isDoingNo;
        private bool _isDoingCancel;
        private bool _isDoingYes;
        private bool _isDoingOK;
        private MessageBoxResponse? _response;
        private readonly ManualResetEvent _responseEvent;

        public MessageBoxViewModel()
        {
            OKCommand = new DelegateCommand(OK, CanDoCommand);
            YesCommand = new DelegateCommand(Yes, CanDoCommand);
            NoCommand = new DelegateCommand(No, CanDoCommand);
            CancelCommand = new DelegateCommand(Cancel, CanDoCommand);
            _responseEvent = new ManualResetEvent(false);
        }

        public MessageBoxViewModel(string title, string message, bool isOKVisible, bool isYesVisible, bool isNoVisible,
                                   bool isCancelVisible) : this()
        {
            Title = title;
            Message = message;
            IsOKVisible = isOKVisible;
            IsYesVisible = isYesVisible;
            IsNoVisible = isNoVisible;
            IsCancelVisible = isCancelVisible;
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged("IsVisible");
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged("Message");
            }
        }

        public bool IsYesVisible
        {
            get { return _isYesVisible; }
            set
            {
                _isYesVisible = value;
                RaisePropertyChanged("IsYesVisible");
            }
        }

        public bool IsNoVisible
        {
            get { return _isNoVisible; }
            set
            {
                _isNoVisible = value;
                RaisePropertyChanged("IsNoVisible");
            }
        }

        public bool IsOKVisible
        {
            get { return _isOKVisible; }
            set
            {
                _isOKVisible = value;
                RaisePropertyChanged("IsOKVisible");
            }
        }

        public bool IsCancelVisible
        {
            get { return _isCancelVisible; }
            set
            {
                _isCancelVisible = value;
                RaisePropertyChanged("IsCancelVisible");
            }
        }

        public DelegateCommand OKCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand YesCommand { get; set; }

        public DelegateCommand NoCommand { get; set; }


        private bool IsDoingOK
        {
            get { return _isDoingOK; }
            set
            {
                _isDoingOK = value;
                OKCommand.RaiseCanExecuteChanged();
            }
        }

        private void OK()
        {
            IsDoingOK = true;
            _response = MessageBoxResponse.OK;
            IsDoingOK = false;
            _responseEvent.Set();
        }

        private bool IsDoingYes
        {
            get { return _isDoingYes; }
            set
            {
                _isDoingYes = value;
                YesCommand.RaiseCanExecuteChanged();
            }
        }

        private void Yes()
        {
            IsDoingYes = true;
            _response = MessageBoxResponse.Yes;
            IsDoingYes = false;
            _responseEvent.Set();
        }

        private bool IsDoingNo
        {
            get { return _isDoingNo; }
            set
            {
                _isDoingNo = value;
                NoCommand.RaiseCanExecuteChanged();
            }
        }

        private void No()
        {
            IsDoingNo = true;
            _response = MessageBoxResponse.No;
            IsDoingNo = false;
            _responseEvent.Set();
        }

        private bool IsDoingCancel
        {
            get { return _isDoingCancel; }
            set
            {
                _isDoingCancel = value;
                CancelCommand.RaiseCanExecuteChanged();
            }
        }

        private void Cancel()
        {
            IsDoingCancel = true;
            _response = MessageBoxResponse.Cancel;
            IsDoingCancel = false;
            _responseEvent.Set();
        }

        private bool CanDoCommand()
        {
            return !IsDoingOK && !IsDoingCancel && !IsDoingNo && !IsDoingYes;
        }


        public async Task<MessageBoxResponse?> GetResponse()
        {
            return await Task.Run(() =>
                {
                    _responseEvent.Reset();
                    _responseEvent.WaitOne();
                    IsVisible = false;
                    return _response;
                });
        }

        public async Task<MessageBoxResponse?> GetResponse(string title, string message, bool isOKVisible, bool isYesVisible, bool isNoVisible, bool isCancelVisible)
        {
            ShowMessageBox(title, message, isOKVisible, isYesVisible, isNoVisible, isCancelVisible);
            return await GetResponse();
        }

        public void ShowMessageBox(string title, string message, bool isOKVisible, bool isYesVisible, bool isNoVisible,
                                   bool isCancelVisible)
        {
            Title = title;
            Message = message;
            IsOKVisible = isOKVisible;
            IsYesVisible = isYesVisible;
            IsNoVisible = isNoVisible;
            IsCancelVisible = isCancelVisible;
            IsVisible = true;
        }
    }
}
