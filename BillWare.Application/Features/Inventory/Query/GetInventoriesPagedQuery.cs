using BillWare.Application.Features.Inventory.Models;
using MediatR;

namespace BillWare.Application.Features.Inventory.Query
{
    public class GetInventoriesPagedQuery : IRequest<PaginationResult<InventoryResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
