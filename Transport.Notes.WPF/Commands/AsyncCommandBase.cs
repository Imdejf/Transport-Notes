using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Transport.Notes.WPF.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private bool _isExecuting;

        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this,new EventArgs());
            }
        }

        public bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }

        public async void Execute(object parameter)
        {
            IsExecuting = true;
            await ExecuteAsync(parameter);
            IsExecuting = false;
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
