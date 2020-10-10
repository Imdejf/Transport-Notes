using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.Factories;

namespace Transport.Notes.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly ITransportNotesViewModelFacotry _viewModelFacotry;

        public UpdateCurrentViewModelCommand(INavigator navigator, ITransportNotesViewModelFacotry viewModelFacotry)
        {
            _navigator = navigator;
            _viewModelFacotry = viewModelFacotry;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                 _navigator.CurrentViewModel = _viewModelFacotry.CreateViewModel(viewType);
            }
        }
    }
}
