using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.VehicleEquipment;

namespace Transport.Notes.WPF.Commands.VehicleEquipmentCommands
{
    public class AddEquipmentCommand : AsyncCommandBase
    {
        private readonly EquipmentViewModel _equipmentViewModel;
        private readonly VehicleState _vehicleState;
        private readonly IEquipmentService _equipmentService ;

        public AddEquipmentCommand(EquipmentViewModel equipmentViewModel, VehicleState vehicleState, IEquipmentService equipmentService)
        {
            _equipmentViewModel = equipmentViewModel;
            _vehicleState = vehicleState;
            _equipmentService = equipmentService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
               string equipmentName = _equipmentViewModel.EquipmentName;
               int quantity =  _equipmentViewModel.Quantity;
               DateTime dateEquipment = _equipmentViewModel.DateEquipment;
                var Task = _equipmentViewModel.VehicleList.FirstOrDefault(s => s.IsSelected);
                int selectedTask = (int)Task.Id;
                Vehicle vehicle = await _equipmentService.AddEquipment(equipmentName, quantity, dateEquipment,_vehicleState.Vehicles.FirstOrDefault(s => s.Id == selectedTask));
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
