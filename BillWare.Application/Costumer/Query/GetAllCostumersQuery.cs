using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Query
{
    public class GetAllCostumersQuery : IRequest<PaginationResult<CostumerVM>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllCostumersQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
