using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.WPF.ViewModel;

namespace Transport.Notes.WPF.State.NavigatorControls
{
    public enum ViewTypeControl
    {
        InventoryControl,
    }
    public interface INavigatorControl
    {
        ViewModelBase CurrentControlViewModel { get; set; }
        event Action StateChanged;
    }
}
