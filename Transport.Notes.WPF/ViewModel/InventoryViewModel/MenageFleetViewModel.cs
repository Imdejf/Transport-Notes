using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Transport.Notes.WPF.Commands.ManageFleetCommands;
using Transport.Notes.WPF.State.CreateVehicle;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel
{
    public class MenageFleetViewModel : ViewModelBase
    {
        public ICommand CreateVehicleCommand { get; set; }

        public MenageFleetViewModel(ICreateVehicleResult createVehicleResult)
            {
            CreateVehicleCommand = new CreateVehicleCommand(this, createVehicleResult);
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
