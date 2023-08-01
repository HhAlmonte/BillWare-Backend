using AutoMapper;
using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Shared;
using BillWare.Application.VehiculoEntrance.Entities;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class CreateVehiculoEntranceCommandHandler : IRequestHandler<CreateVehiculoEntranceCommand, VehiculoEntranceVM>
    {
        private readonly IBaseCrudRepository<VehicleEntranceEntity> _costumerRepository;
        private readonly IMapper _mapper;

        public CreateVehiculoEntranceCommandHandler(IBaseCrudRepository<VehicleEntranceEntity> costumerRepository, IMapper mapper)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
        }

        public async Task<VehiculoEntranceVM> Handle(CreateVehiculoEntranceCommand request, CancellationToken cancellationToken)
        {
            var costumerToCreate = _mapper.Map<VehicleEntranceEntity>(request.CostumerCreate);

            var result = await _costumerRepository.Create(costumerToCreate);

            return _mapper.Map<VehiculoEntranceVM>(result);
        }
    }
}
