using BillWare.Application.Features.Costumer.Models;
using MediatR;

namespace BillWare.Application.Features.Costumer.Query
{
    public class GetCostumersPagedWithSearchQuery : IRequest<PaginationResult<CostumerResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

    }
}
