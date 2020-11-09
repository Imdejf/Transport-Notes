using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.MengeFleet
{
    public class MenageFleetListingViewModel
    {
        private readonly VehicleState _vehicleState;
        private readonly Func<IEnumerable<MenageFleetViewModel>,IEnumerable<MenageFleetViewModel>> _filtersVehicle;
        private readonly ObservableCollection<MenageFleetViewModel> _menageFleetViewModel;

        public IEnumerable<MenageFleetViewModel> MenageFleetView => _menageFleetViewModel;

        public MenageFleetListingViewModel(VehicleState vehicleState, Func<IEnumerable<MenageFleetViewModel>, IEnumerable<MenageFleetViewModel>> filtersVehicle)
        {
            _filtersVehicle = filtersVehicle;
            _vehicleState = vehicleState;
            _menageFleetViewModel = new ObservableCollection<MenageFleetViewModel>();

            _vehicleState.StateChanged += VehicleState_StateChanged;
        }


        private void VehicleState_StateChanged()
        {
            throw new NotImplementedException();
        }
    }
}
