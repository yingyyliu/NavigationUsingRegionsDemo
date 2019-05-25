using Prism.Regions;

namespace NavigationUsingRegionsDemo
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}