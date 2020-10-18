using System;
using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.Factories;

namespace Transport.Notes.WPF.ViewModel.ControlViewModel
{
    public class InventoryControlViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly ITransportNotesViewModelFacotry _viewModelFacotry;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand  UpdateCurrentViewModelCommand { get; }

        public InventoryControlViewModel(INavigator navigator,ITransportNotesViewModelFacotry viewModelFacotry)
        {
            _navigator = navigator;
            _viewModelFacotry = viewModelFacotry;

            _navigator.StateChanged += Navigator_StateChanged;


            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFacotry);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
