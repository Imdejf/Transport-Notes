using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Transport.Notes.WPF.Commands
{
    public class RelayCommand : ICommand
    {
        private Action mAction;
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        public event EventHandler CanExecuteChanged;
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
