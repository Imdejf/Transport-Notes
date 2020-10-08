using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public ICommand RegisterViewCommand { get; set; }

        public RegisterViewModel(IRenavigator registerRenavigator)
        {
            RegisterViewCommand = new RenavigateCommand(registerRenavigator);
        }
    }
}
