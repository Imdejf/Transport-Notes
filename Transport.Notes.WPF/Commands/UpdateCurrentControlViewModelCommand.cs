using System;
using System.Windows.Input;
using Transport.Notes.WPF.State.NavigatorControls;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel.ControlViewModel.FactoriesControl;

namespace Transport.Notes.WPF.Commands
{
    public class UpdateCurrentControlViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigatorControl _navigatorControl;
        private readonly ITransportNotesViewModelControlFacotry _viewModelFacotry;

        public UpdateCurrentControlViewModelCommand(INavigatorControl navigatorControl, ITransportNotesViewModelControlFacotry viewModelFacotry)
        {
            _navigatorControl = navigatorControl;
            _viewModelFacotry = viewModelFacotry;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewTypeControl)
            {
                ViewTypeControl viewTypeControl = (ViewTypeControl)parameter;

                _navigatorControl.CurrentControlViewModel = _viewModelFacotry.CreateViewModel(viewTypeControl);
            }
        }
    }
}
