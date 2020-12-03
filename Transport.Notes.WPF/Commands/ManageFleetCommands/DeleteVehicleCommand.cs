using System;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.WPF.State.Accounts;

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

            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
