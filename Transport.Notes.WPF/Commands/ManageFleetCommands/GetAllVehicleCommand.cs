using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.WPF.State.Accounts;

namespace Transport.Notes.WPF.Commands.ManageFleetCommands
{
    public class GetAllVehicleCommand : AsyncCommandBase
    {
        private readonly IMenageFleetService _menageFleetService;
        private readonly IAccountStore _accountStore;
        public GetAllVehicleCommand(IMenageFleetService menageFleetService, IAccountStore accountStore)
        {
            _menageFleetService = menageFleetService;
            _accountStore = accountStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                Account account = await _menageFleetService.GetAllVehicle(_accountStore.CurrentAccount);
            }
            catch(Exception)
            {
                MessageBox.Show("No record to download");
            }
        }
    }
}
