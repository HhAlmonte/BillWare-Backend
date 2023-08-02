using AutoMapper;
using BillWare.Application.Billing.Models;
using BillWare.Application.Billing.Query;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Billing.Handler
{
    public class GetBillingsPagedQueryHandler : IRequestHandler<GetBillingsPagedQuery, PaginationResult<BillingModel>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public GetBillingsPagedQueryHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BillingModel>> Handle(GetBillingsPagedQuery request, CancellationToken cancellationToken)
        {
            var billings = await _billingRepository.Get(request.PageIndex, request.PageSize);

            var billingsMapped = _mapper.Map<PaginationResult<BillingModel>>(billings);

            return billingsMapped;
        }
    }
}
