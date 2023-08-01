using BillWare.Application.Interfaces;
using BillWare.Application.Vehicle.Command;
using MediatR;

namespace BillWare.Application.Vehicle.Handler
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;

        public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<bool> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var result = await _vehicleRepository.DeleteVehicle(request.Id);

            return result;
        }
    }
}
