using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Query
{
    public class GetCostumersPagedWithSearchQuery : IRequest<PaginationResult<CostumerResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

        public GetCostumersPagedWithSearchQuery(int pageIndex, int pageSize, string search)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Search = search;
        }
    }
}
