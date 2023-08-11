using AutoMapper;
using BillWare.Application.Billing.Models;
using BillWare.Application.Billing.Query;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class GetBillingsWithSearchQueryHandler : IRequestHandler<GetBillingsWithSearchQuery, PaginationResult<BillingModel>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public GetBillingsWithSearchQueryHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BillingModel>> Handle(GetBillingsWithSearchQuery request, CancellationToken cancellationToken)
        {
            var billings = await _billingRepository.GetWithSearch(request.Search, request.PageIndex, request.PageSize);

            var billingsModel = _mapper.Map<PaginationResult<BillingModel>>(billings);

            return billingsModel;
        }
    }
}
