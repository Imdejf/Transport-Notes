﻿using System;
using System.Threading.Tasks;
using Transport.Notes.Domain.Models;

namespace Transport.Notes.Domain.Services.MenageFleetService
{
    public interface IManageFleetService
    {
        Task<Account> AddVehicle(string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registerNumber,
                                DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction,byte [] imageCar,Account accountId);
        Task<bool> DeleteVehicle(int id,Account accountId);
        Task<Account> EditVehicle(string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registerNumber,
                        DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction, byte[] imageCar, Account accountId,int vehicleId);
    }
}
