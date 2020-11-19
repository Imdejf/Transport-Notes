using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services.MenageFleetService;
using Transport.Notes.EntityFramework.Services;
using Transport.Notes.WPF.State.Accounts;
using Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet;

namespace Transport.Notes.WPF.Commands.ManageFleetCommands
{
    public class DeleteVehicleCommand : AsyncCommandBase
    {
        private readonly ManageFleetListingViewModel _manageFleetListingViewModel;
        private readonly IManageFleetService _manageFleetService;
        public DeleteVehicleCommand(ManageFleetListingViewModel manageFleetListingViewModel, IManageFleetService manageFleetService)
        {
            _manageFleetListingViewModel = manageFleetListingViewModel;
            _manageFleetService = manageFleetService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var selectedTask = _manageFleetListingViewModel.Vehicles.Select(x => x.Id)
                .ToList();
            foreach(var tasks in selectedTask)
            {
                if(tasks == (int)parameter)
                {
                  bool result = await _manageFleetService.DeleteVehicle(tasks);
                    if (result == true)
                    {
                        _manageFleetListingViewModel.DeleteItem((int)parameter);
                    }
                }
            }
        }
    }
}
