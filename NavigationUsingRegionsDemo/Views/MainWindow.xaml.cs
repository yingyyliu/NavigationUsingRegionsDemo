using Prism.Regions;
using System;
using System.Windows;

namespace NavigationUsingRegionsDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private fields
        private readonly IRegionManager _regionManager;
        #endregion

        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();

            // View Discovery for Simple Text Region only
            _regionManager = regionManager ?? throw new ArgumentNullException(nameof(regionManager));

            _regionManager.RegisterViewWithRegion("SingleButtonRegion", typeof(SingleButton));
        }

    }
}
