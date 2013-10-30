using System.Windows.Input;
using TheBoyKnowsClass.Common.Models;
using TheBoyKnowsClass.Common.UI.ViewModels;
using TheBoyKnowsClass.Common.UI.WPF.Commands;
using TheBoyKnowsClass.Common.UI.WPF.Models;

namespace TheBoyKnowsClass.Common.UI.WPF.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        public static TestViewModel Instance
        {
            get
            {
                return InstanceCreator<TestViewModel>.Instance;
            }
        }

        public TestViewModel()
        {
            PrismDelegate = new Microsoft.Practices.Prism.Commands.DelegateCommand(Execute, CanExecute);
            MyDelegate = new DelegateCommandWrapper(Execute, CanExecute);
            MyDelegateFromFactory = new DelegateCommandFactory().CreateCommand(Execute, CanExecute);
        }

        public ICommand PrismDelegate;
        public ICommand MyDelegate;
        public ICommand MyDelegateFromFactory;

        private void Execute()
        {
            
        }

        private bool CanExecute()
        {
            return true;
        }
    }
}
