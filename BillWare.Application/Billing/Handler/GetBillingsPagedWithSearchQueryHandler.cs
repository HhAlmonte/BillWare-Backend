using AutoMapper;
using BillWare.Application.Billing.Models;
using BillWare.Application.Billing.Query;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class GetBillingsPagedWithSearchQueryHandler : IRequestHandler<GetBillingsPagedWithSearchQuery, PaginationResult<BillingResponse>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public GetBillingsPagedWithSearchQueryHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BillingResponse>> Handle(GetBillingsPagedWithSearchQuery request, CancellationToken cancellationToken)
        {
            var billings = await _billingRepository.GetEntitiesPagedWithSearch(request.Search, request.PageIndex, request.PageSize);

            var billingsModel = _mapper.Map<PaginationResult<BillingResponse>>(billings);

            return billingsModel;
        }
    }
}
