using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transport.Notes.Domain.Models;
using Transport.Notes.WPF.State.Vehicles;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.ManageFleet
{
    public class VehiclePageViewModel : ViewModelBase
    {
        #region ObservableCollection
        private ObservableCollection<VehicleViewModel> _vehicles = new ObservableCollection<VehicleViewModel>();
        public ObservableCollection<VehicleViewModel> Vehicles
        {
            get
            {
                return _vehicles;
            }
            set
            {
                _vehicles = value;
                OnPropertyChanged(nameof(Vehicles));
            }
        }
        #endregion
        private readonly VehicleState _vehicleState;

        public VehiclePageViewModel(VehicleState vehicleState)
        {
            _vehicleState = vehicleState;
            _vehicles = new ObservableCollection<VehicleViewModel>();

            _vehicleState.StateChanged += _vehicleState_StateChanged;

            ResetVehicles();
        }
        public void ClearList()
        {
            _vehicles.Clear();
        }
        private void ResetVehicles()
        {
            IEnumerable<VehicleViewModel> vehicleViewModels = _vehicleState.GetVehicles
                .Select(s => new VehicleViewModel(s.Id, s.CarBrand, s.VIN, s.Milage, s.EngineNumber, s.EngineCapacity, s.RegistrationNumber, s.FirstRegistration, s.YearPurchase, s.YearProduction, s.ImageCar));
            foreach(var viewModel in vehicleViewModels)
            {
                _vehicles.Add(viewModel);
            }
        }
        private void _vehicleState_StateChanged()
        {
            ResetVehicles();
        }
    }
}
