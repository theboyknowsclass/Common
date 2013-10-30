using System;
using TheBoyKnowsClass.Common.UI.Interfaces;
using TheBoyKnowsClass.Common.UI.WPF.Commands;

namespace TheBoyKnowsClass.Common.UI.WPF.Models
{
    public class DelegateCommandFactory : IDelegateCommandFactory
    {
        public IDelegateCommand CreateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            return new DelegateCommandWrapper(executeMethod, canExecuteMethod);
        }
    }
}
