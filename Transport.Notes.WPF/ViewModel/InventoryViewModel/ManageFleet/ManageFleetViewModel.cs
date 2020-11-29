using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Transport.Notes.Domain.Services.MenageFleetService;
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
        private readonly IAccountStore _accountStore;
        private readonly VehicleState _vehicleState;

        #region Properties
        private string _carBrand { get; set; }
        public string CarBrand
        {
            get
            {
                return _carBrand;
            }
            set
            {
                _carBrand = value;
                OnPropertyChanged(nameof(CarBrand));
            }
        }
        private string _vin { get; set; }
        public string VIN
        {
            get
            {
                return _vin;
            }
            set
            {
                _vin = value;
                OnPropertyChanged(nameof(_vin));
            }
        }
        private string _milage { get; set; }
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
        private string _enigneNumber { get; set; }
        public string EngineNumber
        {
            get
            {
                return _enigneNumber;
            }
            set
            {
                _enigneNumber = value;
                OnPropertyChanged(nameof(EngineNumber));
            }
        }
        private string _engineCapacity { get; set; }
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
        private string _registrationNumber { get; set; }
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
        private DateTime _fristRegistration {get;set;}
        public DateTime FirstRegistration
        {
            get
            {
                if(_fristRegistration.Year == 1) { return DateTime.Now; }
                return _fristRegistration;

            }
            set
            {
                _fristRegistration = value;
                OnPropertyChanged(nameof(FirstRegistration));
            }
        }
        private DateTime _yearPurchase { get; set; }
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
        private DateTime _yearProduction { get; set; }
        public DateTime YearProduction
        {
            get
            {
                if(_yearPurchase.Year == 1) { return DateTime.Now; }
                return _yearProduction;
            }
            set
            {
                _yearProduction = value;
                OnPropertyChanged(nameof(YearProduction));
            }
        }
        private byte[] _imageCar { get; set; }
        public byte[] ImageCar
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
        #endregion

        #region Public Command
        public ICommand CreateVehicleCommand { get; }
        public ICommand UpdateVehicleCommand { get; }
        public ICommand DeleteVehicleCommand { get; }
        public ICommand SelectedItem { get; }
        #endregion

        #region ObservableCollection
        public ObservableCollection<VehicleModel> _vehiclesList = new ObservableCollection<VehicleModel>();
        public ObservableCollection<VehicleModel> VehiclesList
        { 
            get
            {
                return _vehiclesList;
            }
            set
            {
                _vehiclesList = value;
                OnPropertyChanged(nameof(VehiclesList));
            }
        }
        #endregion
        public ManageFleetViewModel(VehicleState vehicleState, IManageFleetService manageFleetService, IAccountStore accountStore)
        {
            SelectedItem = new RelayCommand(DispalySelectedItem);
            CreateVehicleCommand = new CreateVehicleCommand(this,manageFleetService,accountStore);
            DeleteVehicleCommand = new DeleteVehicleCommand(manageFleetService,accountStore);
            UpdateVehicleCommand = new UpdateVehicleCommand(this, accountStore);
            _accountStore = accountStore;
            _vehicleState = vehicleState;

            _vehicleState.StateChanged += _vehicleState_StateChanged;
            ResetVehicles();
        }
        private void DispalySelectedItem()
        {
            var item = VehiclesList.Where(s => s.IsSelected);
            foreach(var task in item)
            {
                CarBrand = task.CarBrand;
                VIN = task.VIN;
                Milage = task.Milage;
                EngineNumber = task.EngineNumber;
                EngineCapacity = task.EngineCapacity;
                RegistrationNumber = task.RegistrationNumber;
                FirstRegistration = task.FirstRegistration;
                YearPurchase = task.YearPurchase;
                YearProduction = task.YearProduction;
                ImageCar = task.ImageCar;
            }
        }
        private void _vehicleState_StateChanged()
        {
            ResetVehicles();
        }

        private void ResetVehicles()
        {
            _vehiclesList.Clear();
            foreach (var task in _accountStore.CurrentAccount.Vehciles.ToList())
            {
                VehiclesList.Add(new VehicleModel
                {
                    IsSelected = false,
                    Id = task.Id,
                    CarBrand = task.CarBrand,
                    VIN = task.VIN,
                    Milage = task.Milage,
                    EngineNumber = task.EngineNumber,
                    EngineCapacity = task.EngineCapacity,
                    RegistrationNumber = task.RegistrationNumber,
                    FirstRegistration = task.FirstRegistration,
                    YearPurchase = task.YearPurchase,
                    ImageCar = task.ImageCar

                });

            }
        }
    }   
}
