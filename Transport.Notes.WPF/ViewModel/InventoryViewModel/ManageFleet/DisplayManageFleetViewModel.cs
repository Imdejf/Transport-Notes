using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.MenageFleet
{
    public class DisplayManageFleetViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string VIN { get; set; }
        public string Milage { get; set; }
        public string EngineNumber { get; set; }
        public string EngineCapacity { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime FirstRegistration { get; set; }
        public DateTime YearPurchase { get; set; }
        public DateTime YearProduction { get; set; }
        public byte[] ImageCar { get; set; }
        public DisplayManageFleetViewModel(int id,string carBrand, string vin, string milage, string engineNumber, string engineCapacity, string registrationNumber, DateTime firstRegistration, DateTime yearPurchase, DateTime yearProduction, byte[] imageCar)
        {
            Id = id;
            CarBrand = carBrand;
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
