using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.WPF.State.Vehicles
{
    public class VehicleState : IVehicleState
    {
        private Vehicle _currentVehicle;
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
