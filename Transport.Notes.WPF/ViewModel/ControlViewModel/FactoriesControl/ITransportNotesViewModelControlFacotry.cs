using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.WPF.State.NavigatorControls;

namespace Transport.Notes.WPF.ViewModel.ControlViewModel.FactoriesControl
{
    public interface ITransportNotesViewModelControlFacotry
    {
        ViewModelBase CreateViewModel(ViewTypeControl controlViewType);
    }
}
