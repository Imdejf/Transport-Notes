using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.State.Equipment;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.VehicleEquipment;

namespace Transport.Notes.WPF.Commands.VehicleEquipmentCommands
{
    public class SelectedEquipmentCommand : AsyncCommandBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IEquipmentState _equipmentState;
        private readonly EquipmentViewModel _equipmentViewModel;
        public SelectedEquipmentCommand(IEquipmentService equipmentService, IEquipmentState equipmentState, EquipmentViewModel equipmentViewModel)
        {
            _equipmentService = equipmentService;
            _equipmentState = equipmentState;
            _equipmentViewModel = equipmentViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
          await _equipmentState.SelectedVehcile((int)parameter);
          _equipmentViewModel.DisplayEquipment();
        }
    }
}
