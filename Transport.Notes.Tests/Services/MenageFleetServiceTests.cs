using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private ManageFleetService _menageFleetService;

        [SetUp]
        public void SetUp()
        {
            _mockVehicleService = new Mock<IVehicleService>();
            _mockAccountService = new Mock<IDataService<Account>>();
            _menageFleetService = new ManageFleetService(_mockAccountService.Object,_mockVehicleService.Object);
        }
        
        [Test]
        public void VINNumberIsAlreadyExists_ReturnInvalidVinNumberException()
        {
            string vin = "TestVinNumber123";
            _mockVehicleService.Setup(s => s.GetByVIN(vin)).ReturnsAsync(new Vehicle());

             InvalidVinNumberException exception = Assert.ThrowsAsync<InvalidVinNumberException>(
                 () => _menageFleetService.AddVehicle(It.IsAny<string>(),vin, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(),It.IsAny<byte []>(),It.IsAny<Account>())
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
                () => _menageFleetService.AddVehicle(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), registrationNumber, It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<byte[]>(), It.IsAny<Account>())
                );
            string actualRegistrationNumber = exception.RegistrationNumber;

            Assert.AreEqual(registrationNumber, actualRegistrationNumber);
        }
        [Test]
        public async Task AddedVehicleSucces_ReturnSucces()
        {
            int expectedAddedVehicle = 1;
            Account vehicleCount = CreateAccount();
            vehicleCount = await _menageFleetService.AddVehicle(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<byte[]>(), vehicleCount);
            int actualAddedVehicle = vehicleCount.Vehcile.Count();
            Assert.AreEqual(expectedAddedVehicle, actualAddedVehicle);
        }
        private Account CreateAccount()
        {
            return new Account()
            {
                Vehcile = new List<Vehicle>()
            };
        }
    }

}
