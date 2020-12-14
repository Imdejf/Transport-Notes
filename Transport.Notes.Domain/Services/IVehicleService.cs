using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services
{
    public interface IVehicleService : IDataService<Vehicle>
    {
        Task<Vehicle> GetByVIN(string vin);
        Task<Vehicle> GetByRegistrationNumber(string registrationNumber);
        Task<Vehicle> GetById(int id);
    }
}
