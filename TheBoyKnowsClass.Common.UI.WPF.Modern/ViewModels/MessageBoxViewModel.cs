using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.UI.Enumerations;
using TheBoyKnowsClass.Common.UI.ViewModels;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.ViewModels
{
    public class MessageBoxViewModel : ViewModelBase
    {

        private string _title;
        private string _message;
        private readonly long _interval;
        private readonly long? _timeOut;
        private readonly Timer _timer;
        private long? _currentTime;
        private readonly MessageBoxButtons _messageBoxButtons;

        private bool _isDoingNo;
        private bool _isDoingCancel;
        private bool _isDoingYes;
        private bool _isDoingOK;
        private bool _isDoingAbort;
        private bool _isDoingIgnore;
        private bool _isDoingRetry;


        private MessageHandlerResponse? _response;
        private readonly ManualResetEvent _responseEvent;

        public MessageBoxViewModel()
        {
            OKCommand = new DelegateCommand(OK, CanDoCommand);
            YesCommand = new DelegateCommand(Yes, CanDoCommand);
            NoCommand = new DelegateCommand(No, CanDoCommand);
            CancelCommand = new DelegateCommand(Cancel, CanDoCommand);
            AbortCommand = new DelegateCommand(Abort, CanDoCommand);
            IgnoreCommand = new DelegateCommand(Ignore, CanDoCommand);
            RetryCommand = new DelegateCommand(Retry, CanDoCommand);

            _responseEvent = new ManualResetEvent(false);
        }

        public MessageBoxViewModel(string title, string message, MessageBoxButtons messageBoxButtons) : this()
        {
            _messageBoxButtons = messageBoxButtons;
            Title = title;
            Message = message;
        }

        public MessageBoxViewModel(string title, string message, long interval, long timeOut, MessageBoxButtons messageBoxButtons)
            : this(title, message, messageBoxButtons)
        {
            _interval = interval;
            _timeOut = timeOut;
            _currentTime = 0;
            _timer = new Timer(TimerCallback, _responseEvent, 0, _interval);
        }

        private void TimerCallback(object state)
        {
            var responseEvent = (ManualResetEvent) state;

            _currentTime += _interval;
            RaisePropertyChanged("ProgressValue");

            if (TimerElapsed != null)
            {
                TimerElapsed(this, new EventArgs());
            }

            if (_currentTime >= _timeOut)
            {
                _response = MessageHandlerResponse.Timeout;
                responseEvent.Set();
                _timer.Dispose();
            }
        }

        public event EventHandler TimerElapsed;

        public ManualResetEvent ResponseEvent
        {
            get
            {
                return _responseEvent;
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

        public bool IsProgressBarVisible
        {
            get
            {
                return _timeOut.HasValue;
            }
        }

        public int ProgressValue
        {
            get
            {
                if (_currentTime != null && _timeOut != null)
                {
                    return 100*(int)_currentTime.Value/(int)_timeOut.Value;
                }
                return 0;
            }
        }

        public bool IsYesVisible
        {
            get
            {
                switch (_messageBoxButtons)
                {
                    case MessageBoxButtons.YesNo:
                    case MessageBoxButtons.YesNoCancel:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsNoVisible
        {
            get
            {
                switch (_messageBoxButtons)
                {
                    case MessageBoxButtons.YesNo:
                    case MessageBoxButtons.YesNoCancel:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsOKVisible
        {
            get
            {
                switch (_messageBoxButtons)
                {
                    case MessageBoxButtons.OK:
                    case MessageBoxButtons.OKCancel:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsCancelVisible
        {
            get
            {
                switch (_messageBoxButtons)
                {
                    case MessageBoxButtons.OKCancel:
                    case MessageBoxButtons.YesNoCancel:
                    case MessageBoxButtons.RetryCancel:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsAbortVisible
        {
            get
            {
                switch (_messageBoxButtons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsIgnoreVisible
        {
            get
            {
                switch (_messageBoxButtons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool IsRetryVisible
        {
            get
            {
                switch (_messageBoxButtons)
                {
                    case MessageBoxButtons.AbortRetryIgnore:
                    case MessageBoxButtons.RetryCancel:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public DelegateCommand OKCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand YesCommand { get; set; }

        public DelegateCommand NoCommand { get; set; }

        public DelegateCommand AbortCommand { get; set; }

        public DelegateCommand RetryCommand { get; set; }

        public DelegateCommand IgnoreCommand { get; set; }


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
            _response = MessageHandlerResponse.OK;
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
            _response = MessageHandlerResponse.Yes;
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
            _response = MessageHandlerResponse.No;
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
            _response = MessageHandlerResponse.Cancel;
            IsDoingCancel = false;
            _responseEvent.Set();
        }

        private bool IsDoingAbort
        {
            get { return _isDoingAbort; }
            set
            {
                _isDoingAbort = value;
                AbortCommand.RaiseCanExecuteChanged();
            }
        }

        private void Abort()
        {
            IsDoingAbort = true;
            _response = MessageHandlerResponse.Abort;
            IsDoingAbort = false;
            _responseEvent.Set();
        }

        private bool IsDoingIgnore
        {
            get { return _isDoingIgnore; }
            set
            {
                _isDoingIgnore = value;
                AbortCommand.RaiseCanExecuteChanged();
            }
        }

        private void Ignore()
        {
            IsDoingIgnore = true;
            _response = MessageHandlerResponse.Ignore;
            IsDoingIgnore = false;
            _responseEvent.Set();
        }

        private bool IsDoingRetry
        {
            get { return _isDoingRetry; }
            set
            {
                _isDoingRetry = value;
                AbortCommand.RaiseCanExecuteChanged();
            }
        }

        private void Retry()
        {
            IsDoingRetry = true;
            _response = MessageHandlerResponse.Retry;
            IsDoingRetry = false;
            _responseEvent.Set();
        }

        private bool CanDoCommand()
        {
            return !IsDoingOK && !IsDoingCancel && !IsDoingNo && !IsDoingYes && !IsDoingAbort && !IsDoingIgnore && !IsDoingRetry;
        }

        public async Task<MessageHandlerResponse?> GetResponseAsync()
        {
            return await Task.Run(() => GetResponse());
        }

        public MessageHandlerResponse? GetResponse()
        {
            _responseEvent.Reset();
            _responseEvent.WaitOne();
            if (_timer != null)
            {
                _timer.Dispose();
            }
            return _response;
        }
    }
}
