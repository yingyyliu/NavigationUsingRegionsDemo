using NavigationUsingRegionsDemo.Views.Settings;
using Prism.Regions;

namespace NavigationUsingRegionsDemo.ViewModels.Settings
{
    public class SettingsMainWindowViewModel : DialogViewModelBase
    {
        public SettingsMainWindowViewModel(IRegionManager regionManager)
        {
            regionManager.RegisterViewWithRegion("SettingRegion", typeof(Setting));
        }
    }
}
