using System.Windows.Input;

namespace TheBoyKnowsClass.Common.UI.Interfaces
{
    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
        void Execute();
        bool CanExecute();
    }
}
