using AutoMapper;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class GetVehiclesEntrancePagedQueryHandler : IRequestHandler<GetVehiclesEntrancePagedQuery, PaginationResult<VehiculoEntranceVM>>
    {
        private readonly IVehicleEntranceRepository _vehicleEntranceRepository;
        private readonly IMapper _mapper;

        public GetVehiclesEntrancePagedQueryHandler(IVehicleEntranceRepository vehicleEntrance, IMapper mapper)
        {
            _vehicleEntranceRepository = vehicleEntrance;
            _mapper = mapper;
        }

        public async Task<PaginationResult<VehiculoEntranceVM>> Handle(GetVehiclesEntrancePagedQuery request, CancellationToken cancellationToken)
        {
            var costumers = await _vehicleEntranceRepository.Get(request.PageIndex, request.PageSize);

            var costumersMapped = _mapper.Map<PaginationResult<VehiculoEntranceVM>>(costumers);

            return costumersMapped;
        }
    }
}
