using BillWare.Application.Billing.Models;
using MediatR;

namespace BillWare.Application.Billing.Query
{
    public class GetBillingsPagedQuery : IRequest<PaginationResult<BillingResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetBillingsPagedQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
