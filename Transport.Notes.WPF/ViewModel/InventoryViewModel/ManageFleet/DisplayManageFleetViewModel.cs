using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet
{
    public class DisplayManageFleetViewModel : ViewModelBase
    {
        public string CarBrand { get; }
        public string VIN { get; }
        public string Milage { get; }
        public string EngineNumber { get; }
        public string EngineCapacity { get; }
        public string RegistrationNumber { get; }
        public DateTime FirstRegistration { get; }
        public DateTime YearPurchase { get; }
        public DateTime YearProduction { get; }
        public byte[] ImageCar { get; }
        public DisplayManageFleetViewModel(string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registrationNumber, DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction, byte[] imageCar)
        {
            CarBrand = "tak";
            VIN = vin;
            Milage = milage;
            EngineNumber = engineNumber;
            EngineCapacity = engineCapacity;
            RegistrationNumber = registrationNumber;
            FirstRegistration = firstRegistration;
            YearPurchase = yearPurchase;
            YearProduction = yearProduction;
            ImageCar = imageCar;  

        }
    }
}
