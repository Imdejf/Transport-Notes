using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _username;
        private string _email;
        private string _password;
        private string _confirmPassword;

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ConfirmPassword
        {
            get
            {
               return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }

        }
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginViewCommand { get; set; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public RegisterViewModel(IAuthenticator authenticator, IRenavigator registerRenavigator, IRenavigator loginRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);
            LoginViewCommand = new RenavigateCommand(loginRenavigator);
        }
    }
}
