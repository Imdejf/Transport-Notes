using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Services.AuthenticationService;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel;

namespace Transport.Notes.WPF.Commands
{
    public class RegisterCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _registerRenavigator;

        public RegisterCommand(RegisterViewModel registerViewModel, IAuthenticator authenticator,IRenavigator registerRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _registerRenavigator = registerRenavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                RegisterResult registerResult = await _authenticator.Register(
                    _registerViewModel.Username,
                    _registerViewModel.Email,
                    _registerViewModel.Password,
                    _registerViewModel.ConfirmPassword);
                switch(registerResult)
                {
                    case RegisterResult.Succes:
                        _registerRenavigator.Renavigator();
                        MessageBox.Show("Succes");
                        break;
                    case RegisterResult.UsernameAlreadyExists:
                        MessageBox.Show("Username");
                        break;
                    case RegisterResult.EmailAlreadyExists:
                        MessageBox.Show("Email");
                        break;
                    case RegisterResult.PasswordDoNotMatch:
                        MessageBox.Show("Password");
                        break;
                    default:
                        MessageBox.Show("Inne");
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
