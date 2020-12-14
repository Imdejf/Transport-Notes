using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.State.Equipment;
using Transport.Notes.WPF.State.Vehicles;

namespace Transport.Notes.WPF.State
{
    public class EquipmentState : IEquipmentState
    {
        private readonly IVehicleState _vehicleState;
        private readonly IEquipmentService _equipmentService;
        public EquipmentState(IVehicleState vehicleState, IEquipmentService equipmentService)
        {
            _vehicleState = vehicleState;
            _equipmentService = equipmentService;
        }
        public Vehicle CurrentVehicle 
        {
            get
            {
                return _vehicleState.CurrentVehicle;
            }
            set
            {
                _vehicleState.CurrentVehicle = value;
                StateChanged?.Invoke();
            }
        }



        public event Action StateChanged;

        public async Task SelectedVehcile(int id)
        {
            CurrentVehicle = await _equipmentService.SelectedVehcile(id);
        }
    }
}
