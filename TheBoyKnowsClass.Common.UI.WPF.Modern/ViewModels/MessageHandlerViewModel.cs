using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheBoyKnowsClass.Common.Models;
using TheBoyKnowsClass.Common.UI.Enumerations;
using TheBoyKnowsClass.Common.UI.Interfaces;
using TheBoyKnowsClass.Common.UI.ViewModels;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.ViewModels
{
    public class MessageHandlerViewModel : ViewModelBase, IMessageHandler
    {
        private readonly Stack<MessageBoxViewModel> _messages;

        public MessageHandlerViewModel()
        {
            _messages = new Stack<MessageBoxViewModel>();
        }

        public static MessageHandlerViewModel Instance
        {
            get
            {
                return InstanceCreator<MessageHandlerViewModel>.Instance;
            }
        }

        public MessageBoxViewModel CurrentMessage
        {
            get
            {
                if (_messages.Count > 0)
                {
                    return _messages.Peek();
                }

                return new MessageBoxViewModel();
            }
        }

        public bool IsVisible
        {
            get
            {
                return _messages.Count > 0;
            }
        }

        public async Task<MessageHandlerResponse?> GetResponseAsync(string title, string message, MessageBoxButtons messageBoxButtons)
        {
            var messageBoxViewModel = CreateAndShowMessageBox(title, message, messageBoxButtons);
            var response = await messageBoxViewModel.GetResponseAsync();
            RemoveAndHideMessageBox();
            return response;
        }

        public async Task<MessageHandlerResponse?> GetResponseAsync(string title, string message, long interval, long timeout, MessageBoxButtons messageBoxButtons, EventHandler timerCallback)
        {
            var messageBoxViewModel = CreateAndShowMessageBox(title, message, interval, timeout, messageBoxButtons);
            CurrentMessage.TimerElapsed += timerCallback;
            var response = await messageBoxViewModel.GetResponseAsync();
            CurrentMessage.TimerElapsed -= timerCallback;
            RemoveAndHideMessageBox();
            return response;
        }

        private MessageBoxViewModel CreateAndShowMessageBox(string title, string message, MessageBoxButtons messageBoxButtons)
        {
            var messageBoxViewModel = new MessageBoxViewModel(title, message, messageBoxButtons);
            return AddAndShowMessageBoxViewModel(messageBoxViewModel);
        }

        private MessageBoxViewModel CreateAndShowMessageBox(string title, string message, long interval, long timeout, MessageBoxButtons messageBoxButtons)
        {
            var messageBoxViewModel = new MessageBoxViewModel(title, message, interval, timeout, messageBoxButtons);
            return AddAndShowMessageBoxViewModel(messageBoxViewModel);
        }

        private MessageBoxViewModel AddAndShowMessageBoxViewModel(MessageBoxViewModel messageBoxViewModel)
        {
            _messages.Push(messageBoxViewModel);
            RaisePropertyChanged("IsVisible");
            RaisePropertyChanged("CurrentMessage");
            return messageBoxViewModel;
        }

        public void HideMessageBox()
        {
            CurrentMessage.ResponseEvent.Set();
        }

        private void RemoveAndHideMessageBox()
        {
            _messages.Pop();
            RaisePropertyChanged("IsVisible");
            RaisePropertyChanged("CurrentMessage");
        }
    }
}
