using System.Windows;
using Prism.Regions;

namespace NavigationUsingRegionsDemo.Helpers.PrismScopedRegion
{
    public static class ScopedRegionManagerAware
    {
        public static IRegionManager RegionManager { get; set; }

        public static void SetRegionManagerAware(object item, IRegionManager regionManager)
        {
            if (item is IScopedRegionManagerAware rmAware)
                rmAware.RegionManager = regionManager;

            if (item is FrameworkElement rmAwareFrameworkElement)
            {
                if (rmAwareFrameworkElement.DataContext is IScopedRegionManagerAware rmAwareDataContext)
                    rmAwareDataContext.RegionManager = regionManager;
            }
        }
    }

    public interface IScopedRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}
