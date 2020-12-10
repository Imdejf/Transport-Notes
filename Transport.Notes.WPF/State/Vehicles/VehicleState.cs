using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using Transport.Notes.Domain.Models;
using Transport.Notes.WPF.State.Accounts;

namespace Transport.Notes.WPF.State.Vehicles
{
    public class VehicleState
    {
        private readonly IAccountStore _accountStore;
        public IEnumerable<Vehicle> Vehicles => _accountStore.CurrentAccount?.Vehciles ?? new List<Vehicle>();
        public event Action StateChanged;
        public VehicleState(IAccountStore accountStore)
        {
            _accountStore = accountStore;
            _accountStore.StateChanged += OnStateChanged;
        }

        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
