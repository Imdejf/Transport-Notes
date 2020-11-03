using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.ViewModel.InventoryViewModel;

namespace Transport.Notes.WPF.Commands.ManageFleetCommands
{
    public class CreateVehicleCommand : AsyncCommandBase
    {
        private readonly MenageFleetViewModel _menageFleetViewModel;
        private readonly IMenageFleetService _menageFleetService;
        private readonly IAccountStore _accountStore;

        public CreateVehicleCommand(MenageFleetViewModel menageFleetViewModel, IMenageFleetService menageFleetService, IAccountStore accountStore)
        {
            _menageFleetViewModel = menageFleetViewModel;
            _menageFleetService = menageFleetService;
            _accountStore = accountStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                string carBrand = _menageFleetViewModel.CarBrand;
                string vin = _menageFleetViewModel.VIN;
                string milage = _menageFleetViewModel.Milage;
                string engineCapacity = _menageFleetViewModel.EngineCapacity;
                string registerNumber = _menageFleetViewModel.RegistrationNumber;
                DateTime firstRegistration = _menageFleetViewModel.FirstRegistration;
                DateTime yearPurchase = _menageFleetViewModel.YearPurchase;
                DateTime yearProduction = _menageFleetViewModel.YearProduction;
                byte[] imageCar = _menageFleetViewModel.ImageCar;


               Account account = await _menageFleetService.AddVehicle(carBrand, vin, milage, engineCapacity, engineCapacity, registerNumber, firstRegistration, yearPurchase, yearProduction, imageCar, _accountStore.CurrentAccount);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
