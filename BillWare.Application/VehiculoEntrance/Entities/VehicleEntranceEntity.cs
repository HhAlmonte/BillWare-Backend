using BillWare.Application.Costumer.Entities;
using BillWare.Application.Shared.Entities;
using BillWare.Application.Vehicle.Entities;

namespace BillWare.Application.VehiculoEntrance.Entities
{
    public class VehicleEntranceEntity : BaseEntity
    {
        public CostumerEntity Costumer { get; set; }

        public List<VehicleEntity> Vehicles { get; set; }
    }
}
