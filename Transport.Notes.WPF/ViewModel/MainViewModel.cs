using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.Factories;

namespace Transport.Notes.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITransportNotesViewModelFacotry _viewModelFacotry;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator,ITransportNotesViewModelFacotry viewModelFacotry,IAuthenticator authenticator)
        {
            _viewModelFacotry = viewModelFacotry;
            _navigator = navigator;
            _authenticator = authenticator;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFacotry);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
