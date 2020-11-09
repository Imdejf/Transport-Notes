using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.Domain.Models
{
    public class Vehicle : DomainObject
    {
        public string CarBrand { get; set; }
        public string VIN { get; set; }
        public string Milage { get; set; }
        public string EnigneNumber { get; set; }
        public string EngineCapacity { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime FirstRegistration { get;set; }
        public DateTime YearPurchase { get; set; }
        public DateTime YearProduction { get; set; }
        public byte[] ImageCar { get; set; }  
        public virtual Account Account { get; set; }
    }
}
