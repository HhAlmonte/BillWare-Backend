using BillWare.Application.VehiculoEntrance.Models;
using MediatR;

namespace BillWare.Application.Vehicle.Command
{
    public class UpdateVehicleCommand : IRequest<VehicleModel>
    {
        public VehicleModel VehicleModel { get; set; }

        public UpdateVehicleCommand(VehicleModel vehicleModel)
        {
            VehicleModel = vehicleModel;
        }
    }
}
