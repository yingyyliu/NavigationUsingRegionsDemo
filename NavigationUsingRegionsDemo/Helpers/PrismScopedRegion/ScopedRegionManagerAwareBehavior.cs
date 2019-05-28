using Prism.Regions;
using System;
using System.Collections.Specialized;
using System.Windows;

namespace NavigationUsingRegionsDemo.Helpers.PrismScopedRegion
{
    public class ScopedRegionManagerAwareBehavior : RegionBehavior
    {
        public const string BehaviorKey = "ScopedRegionManagerAwareBehavior";

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        void ActiveViews_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    IRegionManager regionManager = Region.RegionManager;

                    if (item is FrameworkElement element)
                    {
                        if (element.GetValue(RegionManager.RegionManagerProperty) is IRegionManager scopedRegionManager)
                            regionManager = scopedRegionManager;
                    }

                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = regionManager);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    InvokeOnRegionManagerAwareElement(item, x => x.RegionManager = null);
                }
            }
        }

        static void InvokeOnRegionManagerAwareElement(object item, Action<IScopedRegionManagerAware> invocation)
        {
            if (item is IScopedRegionManagerAware rmAwareItem)
                invocation(rmAwareItem);

            if (item is FrameworkElement frameworkElement &&
                frameworkElement.DataContext is IScopedRegionManagerAware rmAwareDataContext)
            {
                if (frameworkElement.Parent is FrameworkElement frameworkElementParent &&
                    frameworkElementParent.DataContext is IScopedRegionManagerAware rmAwareDataContextParent)
                {
                    if (rmAwareDataContext == rmAwareDataContextParent)
                    {
                        return;
                    }
                }

                invocation(rmAwareDataContext);
            }
        }

        public void Attach()
        {
            throw new NotImplementedException();
        }
    }
}
