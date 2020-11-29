using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF.Commands.ManageFleetCommands
{
    public class UpdateVehicleCommand : ICommand
    {
        private readonly ManageFleetViewModel _manageFleetViewModel;
        private readonly IAccountStore _accountStore;
        private readonly IManageFleetService _manageFleetService;
        public UpdateVehicleCommand(ManageFleetViewModel manageFleetViewModel, IAccountStore accountStore,IManageFleetService manageFleetService)
        {
            _accountStore = accountStore;
            _manageFleetViewModel = manageFleetViewModel;
            _manageFleetService = manageFleetService;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            var selectedTask = _manageFleetViewModel.VehiclesList.FirstOrDefault(s => s.IsSelected);

            try
            {
                if(selectedTask != null)
                {
                    string carBrand = _manageFleetViewModel.CarBrand;
                    string vin = _manageFleetViewModel.VIN;
                    string milage = _manageFleetViewModel.Milage;
                    string engineNumber = _manageFleetViewModel.EngineNumber;
                    string engineCapacity = _manageFleetViewModel.EngineCapacity;
                    string registerNumber = _manageFleetViewModel.RegistrationNumber;
                    DateTime firstRegistration = _manageFleetViewModel.FirstRegistration;
                    DateTime yearPurchase = _manageFleetViewModel.YearPurchase;
                    DateTime yearProduction = _manageFleetViewModel.YearProduction;
                    byte[] imageCar = _manageFleetViewModel.ImageCar;
                    int vehicleId = selectedTask.Id;

                    Account account = await _manageFleetService.EditVehicle(carBrand, vin, milage, engineNumber, engineCapacity, registerNumber, firstRegistration, yearPurchase, yearProduction, imageCar, _accountStore.CurrentAccount,vehicleId);
                }
                else
                {
                    MessageBox.Show("You must select a vehicle");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
