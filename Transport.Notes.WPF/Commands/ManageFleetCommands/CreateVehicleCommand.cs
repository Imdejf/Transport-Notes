using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.EntityFramework.Migrations;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF.Commands.ManageFleetCommands
{
    public class CreateVehicleCommand : AsyncCommandBase
    {
        private readonly ManageFleetViewModel _manageFleetViewModel;
        private readonly IManageFleetService _manageFleetService;
        private readonly IAccountStore _accountStore;
        public CreateVehicleCommand(ManageFleetViewModel menageFleetViewModel, IManageFleetService manageFleetService, IAccountStore accountStore)
        {
            _manageFleetViewModel = menageFleetViewModel;
            _manageFleetService = manageFleetService;
            _accountStore = accountStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                string carBrand = _manageFleetViewModel.CarBrand;
                string vin = _manageFleetViewModel.VIN;
                string milage = _manageFleetViewModel.Milage;
                string engineCapacity = _manageFleetViewModel.EngineCapacity;
                string registerNumber = _manageFleetViewModel.RegistrationNumber;
                DateTime firstRegistration = _manageFleetViewModel.FirstRegistration;
                DateTime yearPurchase = _manageFleetViewModel.YearPurchase;
                DateTime yearProduction = _manageFleetViewModel.YearProduction;
                byte[] imageCar = _manageFleetViewModel.ImageCar;


                Account account = await _manageFleetService.AddVehicle(carBrand, vin, milage, engineCapacity, engineCapacity, registerNumber, firstRegistration, yearPurchase, yearProduction, imageCar, _accountStore.CurrentAccount);
                _accountStore.CurrentAccount = account;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
