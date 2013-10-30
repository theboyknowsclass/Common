using System;

namespace TheBoyKnowsClass.Common.UI.Interfaces
{
    public interface IDelegateCommandFactory
    {
        IDelegateCommand CreateCommand(Action executeMethod, Func<bool> canExecuteMethod);
    }
}
