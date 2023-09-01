using AutoMapper;
using BillWare.Application.BillingService.Entities;
using BillWare.Application.BillingService.Models;
using BillWare.Application.BillingService.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.BillingService.Handler
{
    public class GetBillingsServicesPagedQueryHandler : IRequestHandler<GetBillingsServicePagedQuery, PaginationResult<BillingServiceResponse>>
    {
        private readonly IBaseCrudRepository<BillingServiceEntity> _billingServiceRepository;
        private readonly IMapper _mapper;
        
        public GetBillingsServicesPagedQueryHandler(IBaseCrudRepository<BillingServiceEntity> billingServiceRepository, IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BillingServiceResponse>> Handle(GetBillingsServicePagedQuery request, CancellationToken cancellationToken)
        {
            var billingsServices = await _billingServiceRepository.GetEntitiesPaged(request.Page, request.PageSize);

            var billingsServicesResponse = _mapper.Map<PaginationResult<BillingServiceResponse>>(billingsServices);

            return billingsServicesResponse;
        }
    }
}
