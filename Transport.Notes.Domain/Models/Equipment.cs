using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.Notes.Domain.Models
{
    public class Equipment : DomainObject
    {
        public string EquipmentName { get; set; }
        public int Quantity { get; set; }
        public DateTime DateGive { get; set; }
        public Vehicle VehicleEquipment { get; set; }
    }
}
