using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Features.BillingService.Entities;
using BillWare.Application.Features.BillingService.Models;
using BillWare.Application.Features.Service.Query;
using MediatR;

namespace BillWare.Application.Features.BillingService.Handler
{
    public class GetServicesPagedQueryHandler : IRequestHandler<GetServicesPagedQuery, PaginationResult<ServiceResponse>>
    {
        private readonly IBaseCrudRepository<ServiceEntity> _billingServiceRepository;
        private readonly IMapper _mapper;

        public GetServicesPagedQueryHandler(IBaseCrudRepository<ServiceEntity> billingServiceRepository, IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<ServiceResponse>> Handle(GetServicesPagedQuery request, CancellationToken cancellationToken)
        {
            var servicesPaged = await _billingServiceRepository.GetEntitiesPaged(request.PageIndex, request.PageSize);

            var servicesPagedMapped = _mapper.Map<PaginationResult<ServiceResponse>>(servicesPaged);

            return servicesPagedMapped;
        }
    }
}
