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
        private readonly IRegionManager _scopedSettingsMatinWindowRegionManager;
        #endregion

        #region Public properties

        #endregion

        public SettingsMainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            _regionManager = regionManager;

            _scopedSettingsMatinWindowRegionManager = _regionManager.CreateRegionManager();
            RegionManager.SetRegionManager(this, _scopedSettingsMatinWindowRegionManager);
            _scopedSettingsMatinWindowRegionManager.RegisterViewWithRegion("SettingsMainWindowRegion", typeof(SettingsMainWindow));
        }
    }
}
