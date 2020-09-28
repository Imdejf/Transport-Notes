using System;
using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.Factories;

namespace Transport.Notes.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITransportNotesViewModelFacotry _viewModelFacotry;
        private readonly INavigator _navigator;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(ITransportNotesViewModelFacotry viewModelFacotry, INavigator navigator)
        {
            _viewModelFacotry = viewModelFacotry;
            _navigator = navigator;

            _navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFacotry);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
