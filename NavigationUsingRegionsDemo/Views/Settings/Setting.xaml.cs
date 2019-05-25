using System.Windows.Controls;
using Prism.Regions;

namespace NavigationUsingRegionsDemo.Views.Settings
{
    /// <summary>
    /// Interaction logic for Setting
    /// </summary>
    public partial class Setting : UserControl
    {
        public Setting(IRegionManager regionManager)
        {
            InitializeComponent();
            var scopedRegionManager = regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(ContentControl,scopedRegionManager);

            if (DataContext is IRegionManagerAware rma)
            {
                rma.RegionManager = scopedRegionManager;
            }
        }
    }
}
