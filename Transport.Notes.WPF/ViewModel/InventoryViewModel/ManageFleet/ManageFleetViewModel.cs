using System;
using System.Configuration;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.EntityFramework.Services;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.Commands.ManageFleetCommands;
using Transport.Notes.WPF.Controls;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.ManageFleet;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet
{
    public class ManageFleetViewModel : ViewModelBase
    {
        public string CarBrand { get; set; }
        public string VIN { get; set; }
        public string Milage { get; set; }
        public string EngineNumber { get; set; }
        public string EngineCapacity { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime FirstRegistration { get; set; }
        public DateTime YearPurchase { get; set; }
        public DateTime YearProduction { get; set; }
        public byte[] ImageCar { get; set; }
        public ICommand CreateVehicleCommand { get; }
        public ICommand EditVehicleCommand { get; }
        public ICommand DeleteVehicleCommand { get; }
        public VehiclePageViewModel VehiclePageViewModel{ get; }

        public ManageFleetViewModel(VehicleState vehicleState, IManageFleetService manageFleetService, IAccountStore accountStore)
        {
            VehiclePageViewModel = new VehiclePageViewModel(vehicleState);
            CreateVehicleCommand = new CreateVehicleCommand(this,manageFleetService,accountStore);
            DeleteVehicleCommand = new DeleteVehicleCommand(manageFleetService,accountStore);
        }
    }   
}
