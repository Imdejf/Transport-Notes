using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.State.Equipment;
using Transport.Notes.WPF.State.Vehicles;

namespace Transport.Notes.WPF.Commands.VehicleEquipmentCommands
{
    public class DeleteEquipmentCommand : AsyncCommandBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IVehicleState _vehicleState;
        
        public DeleteEquipmentCommand(IEquipmentService equipmentService, IVehicleState vehicleState)
        {
            _equipmentService = equipmentService;
            _vehicleState = vehicleState;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            bool result = await _equipmentService.DeleteEquipment((int)parameter, _vehicleState.CurrentVehicle);
        }
    }
}
