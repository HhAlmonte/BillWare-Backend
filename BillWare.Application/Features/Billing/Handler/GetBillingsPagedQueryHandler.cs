using AutoMapper;
using BillWare.Application.Features.Billing.Models;
using BillWare.Application.Features.Billing.Query;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Features.Billing.Handler
{
    public class GetBillingsPagedQueryHandler : IRequestHandler<GetBillingsPagedQuery, PaginationResult<BillingResponse>>
    {
        private readonly IBillingRepository _billingRepository;
        private readonly IMapper _mapper;

        public GetBillingsPagedQueryHandler(IBillingRepository billingRepository, IMapper mapper)
        {
            _billingRepository = billingRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<BillingResponse>> Handle(GetBillingsPagedQuery request, CancellationToken cancellationToken)
        {
            var billingsPaged = await _billingRepository.GetEntitiesPaged(request.PageIndex, request.PageSize);

            var billingsPagedMapped = _mapper.Map<PaginationResult<BillingResponse>>(billingsPaged);

            return billingsPagedMapped;
        }
    }
}
