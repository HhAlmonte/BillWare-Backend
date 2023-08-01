using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Query
{
    public class GetInventoryWithSearchQuery : IRequest<PaginationResult<InventoryVM>>
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetInventoryWithSearchQuery(string search, int pageIndex, int pageSize)
        {
            Search = search;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
