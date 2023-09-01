using BillWare.Application.Billing.Models;
using BillWare.Application.BillingService.Models;
using MediatR;

namespace BillWare.Application.BillingService.Query
{
    public class GetBillingsServicePagedQuery : IRequest<PaginationResult<BillingServiceResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetBillingsServicePagedQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
