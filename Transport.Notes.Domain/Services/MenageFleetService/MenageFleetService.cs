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

        public MenageFleetService(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async  Task<Account> AddVehicle(string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registerNumber, DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction, byte[] imageCar,Account accountId)
        {
            if(carBrand == null || vin == null || registerNumber == null)
            {
                throw new Exception();
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
