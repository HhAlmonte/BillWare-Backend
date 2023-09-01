using AutoMapper;
using BillWare.Application.BillingService.Entities;
using BillWare.Application.BillingService.Models;
using BillWare.Application.BillingService.Query;
using BillWare.Application.Shared;
using MediatR;

namespace BillWare.Application.BillingService.Handler
{
    public class GetBillingsServicesPagedWithSearchQueryHandler : IRequestHandler<GetBillingsServicesPagedWithSearchQuery, PaginationResult<BillingServiceResponse>>
    {
        private readonly IBaseCrudRepository<BillingServiceEntity> _billingServiceRepository;
        private readonly IMapper _mapper;

        public GetBillingsServicesPagedWithSearchQueryHandler(IBaseCrudRepository<BillingServiceEntity> billingServiceRepository, IMapper mapper)
        {
            _billingServiceRepository = billingServiceRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BillingServiceResponse>> Handle(GetBillingsServicesPagedWithSearchQuery request, CancellationToken cancellationToken)
        {
            var billingsServices = await _billingServiceRepository.GetEntitiesPagedWithSearch(request.Search, request.Page, request.PageSize);

            var billingsServicesResponse = _mapper.Map<PaginationResult<BillingServiceResponse>>(billingsServices);

            return billingsServicesResponse;
        }
    }
}
