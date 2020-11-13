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
                _registerViewModel.ErrorMessage = string.Empty;

                RegisterResult registerResult = await _authenticator.Register(
                    _registerViewModel.Username,
                    _registerViewModel.Email,
                    _registerViewModel.Password,
                    _registerViewModel.ConfirmPassword);
                switch(registerResult)
                {
                    case RegisterResult.Succes:
                        _registerRenavigator.Renavigator();
                        break;
                    case RegisterResult.UsernameAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this username already exist";
                        break;
                    case RegisterResult.EmailAlreadyExists:
                        _registerViewModel.ErrorMessage = "An account for this email already exist";
                        break;
                    case RegisterResult.PasswordDoNotMatch:
                        _registerViewModel.ErrorMessage = "Password do not match confirm password";
                        break;
                    default:
                        _registerViewModel.ErrorMessage = "Registration failed";
                        break;
                }
            }
            catch(Exception ex)
            {
                _registerViewModel.ErrorMessage = "Registration failed";
            }
        }
    }
}
