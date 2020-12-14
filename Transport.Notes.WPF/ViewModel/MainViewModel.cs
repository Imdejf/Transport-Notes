using System;
using System.Windows;
using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.NavigatorControls;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.ControlViewModel.FactoriesControl;
using Transport.Notes.WPF.ViewModel.Factories;

namespace Transport.Notes.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITransportNotesViewModelFacotry _viewModelFacotry;
        private readonly ITransportNotesViewModelControlFacotry _viewModelFacotryControl;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        private readonly INavigatorControl _navigatorControl;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ViewModelBase CurrentControlViewModel => _navigatorControl.CurrentControlViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand DeleteVehicleCommand { get; set; }
        public ICommand UpdateCurrentControlViewModelCommand { get; }

        public MainViewModel(INavigator navigator,INavigatorControl navigatorControl,ITransportNotesViewModelFacotry viewModelFacotry, ITransportNotesViewModelControlFacotry viewModelFacotryControl, IAuthenticator authenticator)
        {
            _viewModelFacotry = viewModelFacotry;
            _navigator = navigator;
            _authenticator = authenticator;
            _navigatorControl = navigatorControl;
            _viewModelFacotryControl = viewModelFacotryControl;

            _navigator.StateChanged += Navigator_StateChanged;
            _navigatorControl.StateChanged += NavigatorControl_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFacotry);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
            UpdateCurrentControlViewModelCommand = new UpdateCurrentControlViewModelCommand(navigatorControl, _viewModelFacotryControl);
        }

        private void NavigatorControl_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentControlViewModel));
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
