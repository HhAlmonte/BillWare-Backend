using BillWare.Application.BillingService.Models;
using MediatR;

namespace BillWare.Application.BillingService.Query
{
    public class GetBillingsServicesPagedWithSearchQuery : IRequest<PaginationResult<BillingServiceResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

        public GetBillingsServicesPagedWithSearchQuery(int page, int pageSize, string search)
        {
            Page = page;
            PageSize = pageSize;
            Search = search;
        }
    }
}
