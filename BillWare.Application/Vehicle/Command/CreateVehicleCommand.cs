using BillWare.Application.Vehicle.Models;
using MediatR;

namespace BillWare.Application.Vehicle.Command
{
    public class CreateVehicleCommand : IRequest<VehicleModel>
    {
        public VehicleModel VehicleModel { get; set; }

        public CreateVehicleCommand(VehicleModel vehicleModel)
        {
            VehicleModel = vehicleModel;
        }
    }
}
