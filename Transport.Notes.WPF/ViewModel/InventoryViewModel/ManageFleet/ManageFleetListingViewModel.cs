using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet
{
    public class ManageFleetListingViewModel : ViewModelBase
    {
        private readonly VehicleState _vehicleState;
        private readonly Func<IEnumerable<DisplayManageFleetViewModel>,IEnumerable<DisplayManageFleetViewModel>> _filtersVehicle;
        private readonly ObservableCollection<DisplayManageFleetViewModel> _manageFleetViewModel;


        public IEnumerable<DisplayManageFleetViewModel> Vehicles => _manageFleetViewModel;

        public ManageFleetListingViewModel(VehicleState vehicleState) : this(vehicleState, manageFleet => manageFleet) { }

        public ManageFleetListingViewModel(VehicleState vehicleState, Func<IEnumerable<DisplayManageFleetViewModel>, IEnumerable<DisplayManageFleetViewModel>> filtersVehicle)
        {
            _filtersVehicle = filtersVehicle;
            _vehicleState = vehicleState;
            _manageFleetViewModel = new ObservableCollection<DisplayManageFleetViewModel>();

            _vehicleState.StateChanged += VehicleState_StateChanged;
            DisplayVehicles();
        }
        
        private void DisplayVehicles()
        {
            IEnumerable<DisplayManageFleetViewModel> displayManageFleets = _vehicleState.GetVehicles
                .Select(s => new DisplayManageFleetViewModel(s.CarBrand, s.VIN, s.Milage, s.EnigneNumber, s.EngineCapacity, s.RegistrationNumber, s.FirstRegistration, s.YearPurchase, s.YearProduction, s.ImageCar));

             displayManageFleets = _filtersVehicle(displayManageFleets);

            _manageFleetViewModel.Clear();
            foreach (DisplayManageFleetViewModel viewModel in displayManageFleets)
            {
                _manageFleetViewModel.Add(viewModel);
            }
        }
       

        private void VehicleState_StateChanged()
        {
            DisplayVehicles();
        }
    }
}
