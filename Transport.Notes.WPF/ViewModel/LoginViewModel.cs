

using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand ViewRegisterCommand { get; set; }

        public LoginViewModel(IRenavigator registerRenavigator)
        {
            ViewRegisterCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}
