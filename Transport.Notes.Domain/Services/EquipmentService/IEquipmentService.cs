using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.EquipmentService
{
    public interface IEquipmentService
    {
        Task<Vehicle> AddEquipment(string NameEquipment, int Quantity, DateTime DateEquipment,Vehicle vehicleId);
    }
}
