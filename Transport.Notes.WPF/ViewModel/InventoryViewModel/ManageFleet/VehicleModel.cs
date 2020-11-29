using System;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.ManageFleet
{
    public class VehicleModel : ViewModelBase
    {
        public bool IsSelected { get; set; }
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
    }
}
