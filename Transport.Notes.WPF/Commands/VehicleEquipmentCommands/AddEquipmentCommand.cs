﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.State.Equipment;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.VehicleEquipment;

namespace Transport.Notes.WPF.Commands.VehicleEquipmentCommands
{
    public class AddEquipmentCommand : AsyncCommandBase
    {
        private readonly EquipmentViewModel _equipmentViewModel;
        private readonly IEquipmentState _equipmentState;
        private readonly IEquipmentService _equipmentService ;

        public AddEquipmentCommand(EquipmentViewModel equipmentViewModel, IEquipmentState equipmentState, IEquipmentService equipmentService)
        {
            _equipmentViewModel = equipmentViewModel;
            _equipmentState = equipmentState;
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
                Vehicle vehicle = await _equipmentService.AddEquipment(equipmentName, quantity, dateEquipment,_equipmentState.CurrentVehicle);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
