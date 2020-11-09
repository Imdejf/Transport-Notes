using System;
using System.Collections.Generic;
using System.Text;
using Transport.Notes.Domain.Models;
using Transport.Notes.WPF.State.Accounts;

namespace Transport.Notes.WPF.State.Vehicles
{
    public class VehicleState
    {
        private readonly IAccountStore _accountStore;

        public VehicleState(IAccountStore accountStore)
        {
            _accountStore = accountStore;
            _accountStore.StateChanged += OnStateChanged;
        }

        public IEnumerable<Domain.Models.Vehicle> GetVehicles => _accountStore.CurrentAccount?.Vehciles ?? new List<Domain.Models.Vehicle>();

        public event Action StateChanged;

        private void OnStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}
