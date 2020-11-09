using System;
using System.Windows.Input;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.WPF.Commands.ManageFleetCommands;
using Transport.Notes.WPF.State.Accounts;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet
{
    public class MenageFleetViewModel : ViewModelBase
    {
        public ICommand CreateVehicleCommand { get; set; }

        public MenageFleetViewModel(IMenageFleetService menageFleetService, IAccountStore accountStore)
        {
            CreateVehicleCommand = new CreateVehicleCommand(this, menageFleetService, accountStore);
        }

        private string _carbrand { get; set; } //if is problem with added to database look here
        private string _vin { get; set; }
        private string _milage { get; set; }
        private string _enigneNumber { get; set; }
        private string _engineCapacity { get; set; }
        private string _registrationNumber { get; set; }
        private DateTime _firstRegistration { get; set; }
        private DateTime _yearPurchase { get; set; }
        private DateTime _yearProduction { get; set; }
        private byte [] _imageCar { get; set; }

        public string CarBrand
        { 
            get
            {
                return _carbrand;
            }
            set
            {
                _carbrand = value;
                OnPropertyChanged(nameof(CarBrand));
            }
        }
        public string VIN
        {
            get 
            {
                return _vin;
            }
            set
            {
                _vin = value;
                OnPropertyChanged(nameof(VIN));
            }
        }
        public string Milage
        {
            get
            {
                return _milage;
            }
            set
            {
                _milage = value;
                OnPropertyChanged(nameof(Milage));
            }
        }
        public string EnigneNumber
        { 
            get
            {
                return _enigneNumber;
            }
            set
            {
                _enigneNumber = value;
                OnPropertyChanged(nameof(EnigneNumber));
            }
        }
        public string EngineCapacity
        {
            get
            {
                return _engineCapacity;
            }
            set
            {
                _engineCapacity = value;
                OnPropertyChanged(nameof(EngineCapacity));
            }
        }
        public string RegistrationNumber
        { 
            get
            {
                return _registrationNumber;
            }
            set
            {
                _registrationNumber = value;
                OnPropertyChanged(nameof(RegistrationNumber));
            }
        }
        public DateTime FirstRegistration
        {
            get
            {
                if(_firstRegistration.Year == 1) { return DateTime.Now; }
                return _firstRegistration;

            }
            set
            {
                _firstRegistration = value;
                OnPropertyChanged(nameof(FirstRegistration));
            }
        }
        public DateTime YearPurchase
        {
            get
            {
                if(_yearPurchase.Year == 1) { return DateTime.Now; }
                return _yearPurchase;
            }
            set
            {
                _yearPurchase = value;
                OnPropertyChanged(nameof(YearPurchase));
            }
        }
        public DateTime YearProduction
        {
            get
            {
                if (_yearProduction.Year == 1) { return DateTime.Now; }
                return _yearProduction;
            }
            set
            {
                _yearProduction = value;
                OnPropertyChanged(nameof(YearProduction));
            }
        }
        public byte [] ImageCar
        {
            get
            {
                return _imageCar;
            }
            set
            {
                _imageCar = value;
                OnPropertyChanged(nameof(ImageCar));
            }
        }
    }   
}
