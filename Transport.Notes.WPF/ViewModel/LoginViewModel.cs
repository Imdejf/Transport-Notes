

using System.Windows.Controls;
using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Authenticators;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username = "Test";
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

        private string _password = "Test123";
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
        public ICommand ViewRegisterCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigator, IRenavigator registerRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}
