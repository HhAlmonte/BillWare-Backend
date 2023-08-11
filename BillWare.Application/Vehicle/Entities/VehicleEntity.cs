using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Vehicle.Entities
{
    public class VehicleEntity : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public string Plate { get; set; }
        public string? Comments { get; set; }


        public int VehicleEntranceEntityId { get; set; }
    }
}
