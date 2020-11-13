﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.WPF.ViewModel
{
    public class MessageViewModel : ViewModelBase
    {
        private string _message;
        public string Message
        { 
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public bool HasMessage => !string.IsNullOrEmpty(Message);
    }
}
