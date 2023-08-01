using AutoMapper;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Interfaces;
using BillWare.Application.Shared;
using BillWare.Application.VehiculoEntrance.Entities;
using MediatR;

namespace BillWare.Application.Costumer.Handler
{
    public class GetVehiculoEntranceWithParamsQueryHandler : IRequestHandler<GetVehiculoEntranceWithParamsQuery, PaginationResult<VehiculoEntranceVM>>
    {
        private readonly IVehicleEntranceRepository _vehicleEntranceRepository;
        private readonly IMapper _mapper;

        public GetVehiculoEntranceWithParamsQueryHandler(IVehicleEntranceRepository vehicleEntranceRepository, IMapper mapper)
        {
            _vehicleEntranceRepository = vehicleEntranceRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<VehiculoEntranceVM>> Handle(GetVehiculoEntranceWithParamsQuery request, CancellationToken cancellationToken)
        {
            var vehicleEntrance = await _vehicleEntranceRepository.GetWithParams(request.PageIndex, request.PageSize, request.FullName);

            var vehicleEntranceVM = _mapper.Map<PaginationResult<VehiculoEntranceVM>>(vehicleEntrance);

            return vehicleEntranceVM;
        }
    }
}
