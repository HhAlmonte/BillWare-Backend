using AutoMapper;
using BillWare.Application.Interfaces;
using BillWare.Application.Vehicle.Command;
using BillWare.Application.Vehicle.Entities;
using BillWare.Application.Vehicle.Models;
using MediatR;

namespace BillWare.Application.Vehicle.Handler
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, VehicleModel>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleModel> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = _mapper.Map<VehicleEntity>(request.VehicleModel);

            var result = await _vehicleRepository.CreateVehicle(vehicle);

            var resultModel = _mapper.Map<VehicleModel>(result);

            return resultModel;
        }
    }
}
