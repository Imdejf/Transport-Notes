using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Transport.Notes.Domain.Exceptions;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.MenageFleetService
{
    public class ManageFleetService : IManageFleetService
    {
        private readonly IDataService<Account> _accountService;
        private readonly IVehicleService _vehicleService;

        public ManageFleetService(IDataService<Account> accountService, IVehicleService vehicleService)
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
                EngineNumber = engineNumber,
                EngineCapacity = engineCapacity,
                RegistrationNumber = registerNumber,
                FirstRegistration = firstRegistration,
                YearPurchase = yearPurchase,
                YearProduction = yearProduction,
                ImageCar = imageCar,
                Account = accountId
            };
            accountId.Vehciles = new List<Vehicle>();
            accountId.Vehciles.Add(vehicle);
            await _accountService.Update(accountId, accountId.Id);
            return accountId;
        }

        public async Task<bool> DeleteVehicle(int id,Account accountId)
        {
            Account account = accountId as Account;
            bool result = await _vehicleService.Delete(id);
            var task = account.Vehciles.FirstOrDefault(s => s.Id == id);
            account.Vehciles.Remove(task);
            return result;
        }

        public async Task<Account> EditVehicle(string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registerNumber, DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction, byte[] imageCar, Account accountId,int vehicleId)
        {
            var item = accountId.Vehciles.FirstOrDefault(x => x.Id == vehicleId);
            if(item != null)
            {
                item.CarBrand = carBrand;
                item.VIN = vin;
                item.Milage = milage;
                item.EngineNumber = engineNumber;
                item.EngineCapacity = engineCapacity;
                item.RegistrationNumber = registerNumber;
                item.YearPurchase = yearPurchase;
                item.YearProduction = yearProduction;
                item.ImageCar = imageCar;
            }
            await _accountService.Update(accountId, accountId.Id);
            return accountId;
        }
    }
}
