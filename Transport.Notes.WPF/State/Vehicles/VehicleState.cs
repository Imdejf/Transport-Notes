using System;
using System.Collections.Generic;
using Transport.Notes.Domain.Models;
using Transport.Notes.WPF.State.Accounts;

namespace Transport.Notes.WPF.State.Vehicles
{
    public class VehicleState
    {
        private readonly IAccountStore _accountStore;

        public event Action StateChanged;
        public IEnumerable<Vehicle> GetVehicles => _accountStore.CurrentAccount?.Vehciles ?? new List<Vehicle>();

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
