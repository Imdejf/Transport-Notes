using Newtonsoft.Json.Bson;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using Transport.Notes.Domain.Services;
using Transport.Notes.WPF.State.Accounts;
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
        #endregion
        public EquipmentViewModel(IAccountStore accountStore)
        {
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
                    CarBrand = task.CarBrand
                });
            }
        }
    }
}
