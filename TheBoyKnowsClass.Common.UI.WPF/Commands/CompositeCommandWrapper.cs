using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using TheBoyKnowsClass.Common.UI.Interfaces;

namespace TheBoyKnowsClass.Common.UI.WPF.Commands
{
    public class CompositeCommandWrapper : IDelegateCommand, IActiveAware
    {
        private readonly IEnumerable<DelegateCommand> _commands;
        private readonly DelegateCommand _delegateCommand;

        public CompositeCommandWrapper(IEnumerable<DelegateCommand> commands)
        {
            _commands = commands;
            _delegateCommand = new DelegateCommand(Execute, CanExecute);
        }

        public IEnumerable<DelegateCommand> Commands
        {
            get { return _commands; }
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
            foreach (var delegateCommand in _commands.Where(delegateCommand => delegateCommand.CanExecute()))
            {
                delegateCommand.Execute();
            }
        }

        public bool CanExecute()
        {
            return _commands.Any(delegateCommand => delegateCommand.CanExecute());
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
