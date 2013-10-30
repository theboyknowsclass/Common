using System;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.UI.Interfaces;

namespace TheBoyKnowsClass.Common.UI.WPF.Commands
{
    public class DelegateCommandWrapper : IDelegateCommand, IActiveAware
    {
        private readonly DelegateCommand _delegateCommand;

        public DelegateCommandWrapper(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _delegateCommand = new DelegateCommand(executeMethod, canExecuteMethod);
        }

        public bool CanExecute(object parameter)
        {
            return _delegateCommand.CanExecute();
        }

        public void Execute(object parameter)
        {
            _delegateCommand.Execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                _delegateCommand.CanExecuteChanged += value;
            }
            remove
            {
                _delegateCommand.CanExecuteChanged -= value;
            }
        }

        public void RaiseCanExecuteChanged()
        {
            _delegateCommand.RaiseCanExecuteChanged();
        }

        public void Execute()
        {
            _delegateCommand.Execute();
        }

        public bool CanExecute()
        {
            return _delegateCommand.CanExecute();
        }

        public bool IsActive
        {
            get
            {
                return _delegateCommand.IsActive;
            }
            set
            {
                _delegateCommand.IsActive = value;
            }
        }

        public event EventHandler IsActiveChanged
        {
            add
            {
                _delegateCommand.IsActiveChanged += value;
            }
            remove
            {
                _delegateCommand.IsActiveChanged -= value;
            }
        }
    }
}
