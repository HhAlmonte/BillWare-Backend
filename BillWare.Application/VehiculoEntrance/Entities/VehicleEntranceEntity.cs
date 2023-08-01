using BillWare.Application.Shared.Entities;

namespace BillWare.Application.VehiculoEntrance.Entities
{
    public class VehicleEntranceEntity : BaseEntity
    {
        public Costumer Costumer { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
