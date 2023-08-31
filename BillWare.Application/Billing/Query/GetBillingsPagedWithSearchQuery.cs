using BillWare.Application.Billing.Models;
using MediatR;

namespace BillWare.Application.Billing.Query
{
    public class GetBillingsPagedWithSearchQuery : IRequest<PaginationResult<BillingResponse>>
    {
        public string Search { get; set; } 
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetBillingsPagedWithSearchQuery(string search, int pageIndex, int pageSize)
        {
            Search = search;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
