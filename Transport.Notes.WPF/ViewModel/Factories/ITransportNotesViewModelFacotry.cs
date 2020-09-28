using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.WPF.State.Navigators;

namespace Transport.Notes.WPF.ViewModel.Factories
{
    public interface ITransportNotesViewModelFacotry
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
