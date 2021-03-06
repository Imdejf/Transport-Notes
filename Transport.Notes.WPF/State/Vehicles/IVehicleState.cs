﻿using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.WPF.State.Vehicles
{
    public interface IVehicleState
    {
        Vehicle CurrentVehicle { get; set; }
        event Action StateChanged;
    }
}
