using System;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Exceptions;
using Transport.Notes.Domain.Expections;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel;

namespace Transport.Notes.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public override async Task ExecuteAsync(object parameter)
        {
            _loginViewModel.ErrorMessage = string.Empty;
            try
            {
                await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                _renavigator.Renavigator();
            }
            catch(UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Username does not exist";
            }
            catch(InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Incorrect password";
            }
            catch(Exception)
            {
                _loginViewModel.ErrorMessage = "Login filed";
            }
        }
    }
}
