using System;

namespace Transport.Notes.WPF.ViewModel.InventoryViewModel.VehicleEquipment
{
    public class EquipmentModel : ViewModelBase
    {
        public string NameEquipment { get; set; }
        public int Quantity { get; set; }
        public DateTime DateEquipment { get; set; }
    }
}
