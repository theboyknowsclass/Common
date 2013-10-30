using System.Windows.Navigation;

namespace TheBoyKnowsClass.Common.UI.WPF.Modern.Interfaces
{
    public interface IModernPage
    {
        void OnNavigating(NavigatingCancelEventArgs e);
    }
}
