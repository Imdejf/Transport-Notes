using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.MenageFleetService
{
    public enum VehicleResult
    { 
     Succes,
     NotAllFieldsAreFilled,
     PictureWithWrongFormat,
     VINNumberAlreadyExists,
     RegistrationNumberAlreadyExists
    }
    public interface IManageFleetService
    {
        Task<Account> AddVehicle(string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registerNumber,
                                DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction,byte [] imageCar,Account accountId);
    }
}
