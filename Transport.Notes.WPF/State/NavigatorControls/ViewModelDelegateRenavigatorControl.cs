using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.WPF.ViewModel;

namespace Transport.Notes.WPF.State.NavigatorControls
{
    public class ViewModelDelegateRenavigatorControl<TViewModel> : IRenavigatorControl where TViewModel : ViewModelBase
    {
        private readonly INavigatorControl _navigatorControl;
        private readonly CreateViewModel<TViewModel> _createControlViewModel;

        public ViewModelDelegateRenavigatorControl(INavigatorControl navigatorControl, CreateViewModel<TViewModel> createControlViewModel)
        {
            _navigatorControl = navigatorControl;
            _createControlViewModel = createControlViewModel;

        }

        public void RenavigatorControl()
        {
            _navigatorControl.CurrentControlViewModel = _createControlViewModel();
        }
    }
}
