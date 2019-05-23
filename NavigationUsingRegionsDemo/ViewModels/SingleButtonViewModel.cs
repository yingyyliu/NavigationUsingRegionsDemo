using NavigationUsingRegionsDemo.ViewModels.Commands;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NavigationUsingRegionsDemo.ViewModels
{
    public class SingleButtonViewModel : BindableBase
    {
        #region Private Fields
        private readonly ICommandMap _commands;
        private readonly IDialogService _diagService;
        #endregion

        #region Public Properties
        public ICommandMap Commands => _commands;
        #endregion

        public SingleButtonViewModel(ICommandMap commands, IDialogService dialService)
        {
            _commands = commands;
            _diagService = dialService;
            _commands.AddCommand("ShowWindowCommand", ShowWindow);
        }

        private void ShowWindow(object windowName)
        {
            _diagService.ShowDialog(windowName.ToString(), new DialogParameters(), null);
        }
    }
}
