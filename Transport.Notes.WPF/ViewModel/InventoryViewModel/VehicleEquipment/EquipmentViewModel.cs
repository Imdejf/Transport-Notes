using Newtonsoft.Json.Converters;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.Commands;
using Transport.Notes.WPF.Commands.VehicleEquipmentCommands;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.State.Equipment;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.ManageFleet;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.VehicleEquipment
{
    public class EquipmentViewModel : ViewModelBase
    {
        private readonly IVehicleState _vehicleState;
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
        public ICommand SelectedVehcile { get; set; }
        public ICommand SelectCommand { get; set; }

        #endregion

        public EquipmentViewModel(IAccountStore accountStore,IEquipmentService equipmentService,IEquipmentState equipmentState, IVehicleState vehicleState)
        {
            SelectCommand = new SelectedEquipmentCommand(equipmentService, equipmentState, this);
            AddEquipmentCommand = new AddEquipmentCommand(this,equipmentState,equipmentService);
            _accountStore = accountStore;
            _vehicleState = vehicleState;
            DisplayVehicle();
        }
        public void DisplayEquipment()
        {
            foreach(var task in _vehicleState.CurrentVehicle.Equipment)
            {
                EquipmentList.Add(new EquipmentModel
                {
                    NameEquipment = task.EquipmentName,
                    Quantity = task.Quantity,
                    DateEquipment = task.DateGive,
                });;
            }
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
