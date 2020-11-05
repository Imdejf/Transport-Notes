using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Exceptions;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.MenageFleetService
{
    public class MenageFleetService : IMenageFleetService
    {
        private readonly IDataService<Account> _accountService;
        private readonly IVehicleService _vehicleService;

        public MenageFleetService(IDataService<Account> accountService, IVehicleService vehicleService)
        {
            _accountService = accountService;
            _vehicleService = vehicleService;
        }
        public async  Task<Account> AddVehicle(string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registerNumber, DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction, byte[] imageCar,Account accountId)
        {
            Vehicle vehicleVIN = await _vehicleService.GetByVIN(vin);
            if(vehicleVIN != null)
            {
                throw new InvalidVinNumberException(vin);
            }
            Vehicle vehicleRegistraion = await _vehicleService.GetByRegistrationNumber(registerNumber);
            if(vehicleRegistraion != null)
            {
                throw new InvalidRegistrationNumberException(registerNumber);
            }
            Vehicle vehicle = new Vehicle()
            {
                CarBrand = carBrand,
                VIN = vin,
                Milage = milage,
                EnigneNumber = engineNumber,
                EngineCapacity = engineCapacity,
                RegistrationNumber = registerNumber,
                FirstRegistration = firstRegistration,
                YearPurchase = yearPurchase,
                YearProduction = yearProduction,
                ImageCar = imageCar,
                Account = accountId
            };
            accountId.Vehcile = new List<Vehicle>();
            accountId.Vehcile.Add(vehicle);
            await _accountService.Update(accountId, accountId.Id);

            return accountId;
        }
    }
}
