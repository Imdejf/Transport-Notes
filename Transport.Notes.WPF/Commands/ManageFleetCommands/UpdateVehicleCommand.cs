using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.ManageFleet;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF.Commands.ManageFleetCommands
{
    public class UpdateVehicleCommand : ICommand
    {
        private readonly ManageFleetViewModel _manageFleetViewModel;
        private readonly IAccountStore _accountStore;
        public UpdateVehicleCommand(ManageFleetViewModel manageFleetViewModel, IAccountStore accountStore)
        {
            _accountStore = accountStore;
            _manageFleetViewModel = manageFleetViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var selectedTask = _manageFleetViewModel.VehiclesList.FirstOrDefault(s => s.IsSelected);
        }
    }
}
