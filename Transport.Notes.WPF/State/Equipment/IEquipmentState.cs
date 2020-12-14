using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.WPF.State.Equipment
{
    public interface IEquipmentState
    {
        Vehicle CurrentVehicle { get; set; }
        Task SelectedVehcile(int id);
        event Action StateChanged; 
    }
}
