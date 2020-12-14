using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.EquipmentService;
using Transport.Notes.WPF.Controls;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.VehicleEquipment;

namespace Transport.Notes.WPF.State.Vehicles
{
    public class VehicleState : IVehicleState
    {
        private Vehicle _currentVehicle { get; set; }
        
        public Vehicle CurrentVehicle
        {
            get
            {
                return _currentVehicle;
            }
            set
            {
                _currentVehicle = value;
                StateChanged?.Invoke();
            }
        }
        public event Action StateChanged;

    }
}
