using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Transport.Notes.Domain.Exceptions;
using Transport.Notes.Domain.Models;
using Transport.Notes.Domain.Services;
using Transport.Notes.Domain.Services.MenageFleetService;

namespace Transport.Notes.Tests.Services
{
    public class MenageFleetServiceTests
    {
        private Mock<IVehicleService> _mockVehicleService;
        private Mock<IDataService<Account>> _mockAccountService;
        private ManageFleetService _manageFleetService;

        [SetUp]
        public void SetUp()
        {
            _mockVehicleService = new Mock<IVehicleService>();
            _mockAccountService = new Mock<IDataService<Account>>();
            _manageFleetService = new ManageFleetService(_mockAccountService.Object,_mockVehicleService.Object);
        }
        
        [Test]
        public void VINNumberIsAlreadyExists_ReturnInvalidVinNumberException()
        {
            string vin = "TestVinNumber123";
            _mockVehicleService.Setup(s => s.GetByVIN(vin)).ReturnsAsync(new Vehicle());

             InvalidVinNumberException exception = Assert.ThrowsAsync<InvalidVinNumberException>(
                 () => _manageFleetService.AddVehicle(It.IsAny<string>(),vin, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(),It.IsAny<byte []>(),It.IsAny<Account>())
           );
            string actualInvalidVin = exception.VIN;

            Assert.AreEqual(vin, actualInvalidVin);
        }
        [Test]
        public void RegisterNumberIsAlreadyExists_ReturnInvalidRegistrationNumberException()
        {
            string registrationNumber = "TestRegistrationNumber123";
            _mockVehicleService.Setup(s => s.GetByRegistrationNumber(registrationNumber)).ReturnsAsync(new Vehicle());

            InvalidRegistrationNumberException exception = Assert.ThrowsAsync<InvalidRegistrationNumberException>(
                () => _manageFleetService.AddVehicle(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), registrationNumber, It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<byte[]>(), It.IsAny<Account>())
                );
            string actualRegistrationNumber = exception.RegistrationNumber;

            Assert.AreEqual(registrationNumber, actualRegistrationNumber);
        }
        [Test]
        public async Task AddedVehicleSucces_ReturnSucces()
        {
            int expectedAddedVehicle = 1;
            Account vehicleCount = CreateAccount();
            vehicleCount = await _manageFleetService.AddVehicle(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<byte[]>(), vehicleCount);
            int actualAddedVehicle = vehicleCount.Vehciles.Count();
            Assert.AreEqual(expectedAddedVehicle, actualAddedVehicle);
        }

        [Test]
        public async Task DeleteVehicle_ReturnSuccess()
        {
            int expected = 0;
            Account account = CreateAccount();
            Vehicle vehicle = new Vehicle() { Id = 5 };
            account.Vehciles.Add(vehicle);
            await _manageFleetService.DeleteVehicle(5, account);
            int actual = account.Vehciles.Count();
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public async Task DeleteVehicle_ReturnFail_VehicleWithThisIdDoesNotExist()
        {
            int expected = 1;
            Account account = CreateAccount();
            Vehicle vehicle = new Vehicle() { Id = 5 };
            account.Vehciles.Add(vehicle);
            await _manageFleetService.DeleteVehicle(6, account);
            int acutal = account.Vehciles.Count();
            Assert.AreEqual(expected, acutal);
        }

        [Test]
        public async Task EditVehcile_ReturnSuccess()
        {
            string expected = "TestNew";
            Account account = CreateAccount();
            Vehicle vehicle = new Vehicle() { Id = 5, CarBrand = "TestOld"};
            account.Vehciles.Add(vehicle);
            await _manageFleetService.EditVehicle(expected, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<byte[]>(), account, 5);
            string actual = vehicle.CarBrand;
        }
        private Account CreateAccount()
        {
            return new Account()
            {
            Id = 5,
            Vehciles = new List<Vehicle>()
            };
            
        }
        
    }

}
