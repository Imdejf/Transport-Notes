using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.EntityFramework.Services;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.Commands.ManageFleetCommands;
using Transport.Notes.WPF.Controls;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet
{
    public class ManageFleetListingViewModel : ViewModelBase
    {
        private readonly Func<IEnumerable<DisplayManageFleetViewModel>,IEnumerable<DisplayManageFleetViewModel>> _filtersVehicle;
        private readonly ObservableCollection<DisplayManageFleetViewModel> _manageFleetViewModel;
        private readonly VehicleState _vehicleState;
        private readonly IManageFleetService _manageFleetService;

        public IEnumerable<DisplayManageFleetViewModel> Vehicles => _manageFleetViewModel;

        public ICommand DeleteVehicleCommand { get; set; }


        public ManageFleetListingViewModel(VehicleState vehicleState, IManageFleetService manageFleetService) : this(vehicleState,manageFleetService, manageFleet => manageFleet) { }

        public ManageFleetListingViewModel(VehicleState vehicleState, IManageFleetService manageFleetService, Func<IEnumerable<DisplayManageFleetViewModel>, IEnumerable<DisplayManageFleetViewModel>> filtersVehicle )
        {
            DeleteVehicleCommand = new DeleteVehicleCommand(this,manageFleetService);
            _filtersVehicle = filtersVehicle;
            _vehicleState = vehicleState;
            _manageFleetService = manageFleetService;
            _manageFleetViewModel = new ObservableCollection<DisplayManageFleetViewModel>();

            _vehicleState.StateChanged += VehicleState_StateChanged;
            DisplayVehicles();
        }
        
        private void DisplayVehicles()
        {
            IEnumerable<DisplayManageFleetViewModel> displayManageFleets = _vehicleState.GetVehicles
                .Select(s => new DisplayManageFleetViewModel(s.Id, s.CarBrand, s.VIN, s.Milage, s.EnigneNumber, s.EngineCapacity, s.RegistrationNumber, s.FirstRegistration, s.YearPurchase, s.YearProduction, s.ImageCar));

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
