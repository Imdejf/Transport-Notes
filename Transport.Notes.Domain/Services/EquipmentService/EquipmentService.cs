using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transport.Notes.Domain.Exceptions;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.EquipmentService
{
    public class EquipmentService : IEquipmentService
    {
        public readonly IDataService<Vehicle> _vehicleDataService;
        public readonly IVehicleService _vehicleService;
        public EquipmentService(IDataService<Vehicle> vehicleDataService,IVehicleService vehicleService)
        {
            _vehicleDataService = vehicleDataService;
            _vehicleService = vehicleService;
        }
        public async Task<Vehicle> AddEquipment(string equipmentName, int quantity, DateTime dateEquipment,Vehicle vehicleId)
        {
            if(equipmentName.Length <= 2)
            {
                throw new CompleteFiledException(equipmentName);
            }
            if (quantity == 0)
            {
                throw new GetNumberException(quantity);
            }
            Equipment equipment = new Equipment()
            {
                EquipmentName = equipmentName,
                Quantity = quantity,
                DateGive = dateEquipment,
                VehicleEquipment = vehicleId
            };
            vehicleId.Equipment = new List<Equipment>();
            vehicleId.Equipment.Add(equipment);
            await _vehicleDataService.Update(vehicleId, vehicleId.Id);
            return vehicleId;
        }

        public async Task<bool> DeleteEquipment(int id, Vehicle vehicle)
        {
            await _vehicleService.DeleteEquipment(id);
            var task = vehicle.Equipment.FirstOrDefault(e => e.Id == id);
            vehicle.Equipment.Remove(task);
            return true;
        }
    }
}
