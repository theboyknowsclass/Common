using System.Windows.Controls;
using TheBoyKnowsClass.Common.UI.WPF.ViewModels;
using TheBoyKnowsClass.SystemServices.Common.UI.ViewModels;

namespace TheBoyKnowsClass.SystemServices.Common.UI.Controls
{
    /// <summary>
    /// Interaction logic for SystemServiceManagerControl.xaml
    /// </summary>
    public partial class SystemServiceManagerControl : UserControl
    {
        public SystemServiceManagerControl()
        {
            InitializeComponent();           
        }

        public void LoadFromService(SystemServiceViewModel systemService)
        {
            DataContext = new
            {
                Service = systemService,
                UAC = new UserAccountControlViewModel(),
            }; 

        }
    }
}
