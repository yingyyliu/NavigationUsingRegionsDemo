using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using PropertyChanged;
using System.Windows.Documents;
using Prism.Ioc;
using Prism.Regions;
using System.Windows.Input;
using System.Windows.Controls;

namespace NavigationUsingRegionsDemo.ViewModels.Settings
{
    public class SettingViewModel : BindableBase
    {
        #region Private fields
        private readonly IContainerExtension _container;
        private IRegionManager _regionManager;
        private List<String> _things;
        #endregion

        #region Public properties

        public List<String> Things
        {
            get
            {
                return new List<string>() {
                    "Item A",
                    "Item B",
                    "Item C"};
            }
            set
            {
                _things = value;
            }
        }


        public string SelectedThing { get; set; }

        public ICommand ThingChangedCommand { get; }

        #endregion


        public SettingViewModel(IContainerExtension container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;

            ThingChangedCommand = new DelegateCommand<SelectionChangedEventArgs>(OnThingChanged);
        }

        private void OnThingChanged(SelectionChangedEventArgs e)
        {
            string currThing = SelectedThing;

            if (string.Compare(currThing, "Item A", true) == 0)
            {
                _regionManager.RequestNavigate("ViewInjectionRegion", "ItemA");
            }
            else if (string.Compare(currThing, "Item B", true) == 0)
            {
                _regionManager.RequestNavigate("ViewInjectionRegion", "ItemB");
            }
  
        }
    }
}
