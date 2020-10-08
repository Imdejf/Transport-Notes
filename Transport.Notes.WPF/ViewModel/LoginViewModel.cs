

using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand ViewRegisterCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IRenavigator registerRenavigator,IRenavigator loginRenavigator)
        {
            LoginCommand = new LoginCommand(this,loginRenavigator);
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}
