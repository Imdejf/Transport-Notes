using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.WPF.ViewModel;

namespace Transport.Notes.WPF.State.Navigators
{
  public enum ViewType
    {
        Login,
        Start,
        DriversBase,
        MenageFleet,
        VehicleEquipment,
        GeneralInformation
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }  
}
