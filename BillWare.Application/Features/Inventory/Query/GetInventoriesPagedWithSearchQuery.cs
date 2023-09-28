using BillWare.Application.Features.Inventory.Models;
using MediatR;

namespace BillWare.Application.Features.Inventory.Query
{
    public class GetInventoriesPagedWithSearchQuery : IRequest<PaginationResult<InventoryResponse>>
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
