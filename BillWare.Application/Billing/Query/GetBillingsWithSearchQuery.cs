using BillWare.Application.Billing.Models;
using MediatR;

namespace BillWare.Application.Billing.Query
{
    public class GetBillingsWithSearchQuery : IRequest<PaginationResult<BillingModel>>
    {
        public string Search { get; set; } 
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetBillingsWithSearchQuery(string search, int pageIndex, int pageSize)
        {
            Search = search;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
