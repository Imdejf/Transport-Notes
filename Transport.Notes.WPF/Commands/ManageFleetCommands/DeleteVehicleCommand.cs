using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.State.Vehicles;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.ManageFleet;

namespace Transport.Notes.WPF.Commands.ManageFleetCommands
{
    public class DeleteVehicleCommand : AsyncCommandBase
    {
        private readonly IManageFleetService _manageFleetService;
        private readonly IAccountStore _accountStore;
        public DeleteVehicleCommand(IManageFleetService manageFleetService, IAccountStore accountStore)
        {
            _manageFleetService = manageFleetService;
            _accountStore = accountStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                bool result = await _manageFleetService.DeleteVehicle((int)parameter,_accountStore.CurrentAccount);
                if (result != true)
                {
                    MessageBox.Show("You cannot delete the item");
                }

                _accountStore.CurrentAccount = _accountStore.CurrentAccount;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
