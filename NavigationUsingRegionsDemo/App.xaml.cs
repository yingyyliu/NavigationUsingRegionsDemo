using NavigationUsingRegionsDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using NavigationUsingRegionsDemo.ViewModels.Commands;
using NavigationUsingRegionsDemo.Views.Settings;
using NavigationUsingRegionsDemo.ViewModels.Settings;

namespace NavigationUsingRegionsDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<SettingsMainWindow, SettingsMainWindowViewModel>();
            containerRegistry.RegisterForNavigation<ItemA>();
            containerRegistry.RegisterForNavigation<ItemB>();

            containerRegistry.Register<ICommandMap, CommandMap>();
        }

        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);
            regionBehaviors.AddIfMissing(RegionManagerAwareBehavior.BehaviorKey,typeof(RegionManagerAwareBehavior));
        }
    }
}
