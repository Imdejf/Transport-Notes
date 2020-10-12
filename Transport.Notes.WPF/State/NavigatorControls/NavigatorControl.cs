using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.WPF.ViewModel;

namespace Transport.Notes.WPF.State.NavigatorControls
{
    public class NavigatorControl : INavigatorControl
    {
        private ViewModelBase _currentControlViewModel;
        public ViewModelBase CurrentControlViewModel
        {
            get
            {
                return _currentControlViewModel;
            }
            set
            {
                _currentControlViewModel = value;
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
