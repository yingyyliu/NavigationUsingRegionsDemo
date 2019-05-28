using CommonServiceLocator;
using DryIoc;
using Prism.DryIoc;
using Prism.Regions;
using Prism.Ioc;
using System.Windows;
using System.Windows.Controls;

namespace NavigationUsingRegionsDemo.Views.Settings
{
    /// <summary>
    /// Interaction logic for SettingsMainWindow
    /// </summary>
    public partial class SettingsMainWindow : UserControl
    {
        #region Private fields
        private readonly IRegionManager _regionManager;
        private readonly IContainerExtension _containerExtension;
        #endregion

        public SettingsMainWindow(IContainerExtension containerExtension, IRegionManager regionManager)
        {
            InitializeComponent();
            _containerExtension = containerExtension;
            _regionManager = regionManager;

            RegionManager.SetRegionManager(this, _regionManager);
            _regionManager.RegisterViewWithRegion("SettingRegion", typeof(Setting));
        }
    }
}
