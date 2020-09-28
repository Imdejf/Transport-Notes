using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Transport.Notes.WPF.State.Navigators;
using Transport.Notes.WPF.ViewModel;

namespace Transport.Notes.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _renavigator = renavigator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
