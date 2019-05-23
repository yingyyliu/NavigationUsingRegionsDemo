using CommonServiceLocator;
using DryIoc;
using Prism.DryIoc;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;

namespace NavigationUsingRegionsDemo.Views.Settings
{
    /// <summary>
    /// Interaction logic for SettingsMainWindow
    /// </summary>
    public partial class SettingsMainWindow : UserControl
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainer _container;

        public SettingsMainWindow()
        {
            InitializeComponent();
            _container = ((App)Application.Current).Container.GetContainer();
            _regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            _regionManager.RegisterViewWithRegion("SettingRegion", typeof(Setting));
        }
    }
}
