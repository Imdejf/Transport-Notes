using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.Commands.VehicleEquipmentCommands;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.ManageFleet;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.VehicleEquipment
{
    public class EquipmentViewModel : ViewModelBase
    {
        private readonly IAccountStore _accountStore;
        #region ObservableCollection
        private ObservableCollection<VehicleModel> _vehicleList = new ObservableCollection<VehicleModel>();
        public ObservableCollection<VehicleModel> VehicleList
        {
            get
            {
                return _vehicleList;
            }
            set
            {
                _vehicleList = value;
                OnPropertyChanged(nameof(VehicleList));
            }
        }

        private ObservableCollection<EquipmentModel> _equipmentList = new ObservableCollection<EquipmentModel>();
        public ObservableCollection<EquipmentModel> EquipmentList
        { 
            get
            {
                return _equipmentList;
            }
            set
            {
                _equipmentList = value;
                OnPropertyChanged(nameof(EquipmentList));
            }
        }
        #endregion
        #region Properties
        private string _equipmentName { get; set; }
        public string EquipmentName
        {
            get
            {
                return _equipmentName;
            }
            set
            {
                _equipmentName = value;
                OnPropertyChanged(nameof(EquipmentName));
            }
        }
        private int _quantity { get; set; }
        public int Quantity
        { 
            get
            {
                if(_quantity == 0) {  }
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        private DateTime _dateEquipment { get; set; }
        public DateTime DateEquipment
        {
            get
            {
                return _dateEquipment;
            }
            set
            {
                _dateEquipment = value;
                OnPropertyChanged(nameof(DateEquipment));
            }
        }
        #endregion
        #region Command
        public ICommand AddEquipmentCommand { get; set; } 
        #endregion
        public EquipmentViewModel(IAccountStore accountStore, VehicleState vehicleState,IEquipmentService equipmentService)
        {
            AddEquipmentCommand = new AddEquipmentCommand(this,vehicleState,equipmentService);
            _accountStore = accountStore;
            DisplayVehicle();
        }

        private void DisplayVehicle()
        {
            _vehicleList.Clear();
            foreach (var task in _accountStore.CurrentAccount.Vehciles.ToList())
            {
                VehicleList.Add(new VehicleModel
                {
                    CarBrand = task.CarBrand,
                    VIN = task.VIN,
                    FirstRegistration = task.FirstRegistration,
                    RegistrationNumber = task.RegistrationNumber,
                    Milage = task.Milage,
                    YearPurchase = task.YearPurchase,
                    ImageCar = task.ImageCar,
                    Id = task.Id
                }) ;
            }
        }
    }
}
