using AutoMapper;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class GetAllVehiculoEntranceQueryHandler : IRequestHandler<GetAllVehiculoEntranceQuery, PaginationResult<VehiculoEntranceVM>>
    {
        private readonly IVehicleEntranceRepository _vehicleEntranceRepository;
        private readonly IMapper _mapper;

        public GetAllVehiculoEntranceQueryHandler(IVehicleEntranceRepository vehicleEntrance, IMapper mapper)
        {
            _vehicleEntranceRepository = vehicleEntrance;
            _mapper = mapper;
        }

        public async Task<PaginationResult<VehiculoEntranceVM>> Handle(GetAllVehiculoEntranceQuery request, CancellationToken cancellationToken)
        {
            var costumers = await _vehicleEntranceRepository.Get(request.PageIndex, request.PageSize);

            var costumersMapped = _mapper.Map<PaginationResult<VehiculoEntranceVM>>(costumers);

            return costumersMapped;
        }
    }
}
