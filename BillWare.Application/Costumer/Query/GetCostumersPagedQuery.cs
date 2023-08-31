using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Query
{
    public class GetCostumersPagedQuery : IRequest<PaginationResult<CostumerResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetCostumersPagedQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
