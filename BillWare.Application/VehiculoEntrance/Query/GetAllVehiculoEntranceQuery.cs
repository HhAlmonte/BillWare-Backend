using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Query
{
    public class GetAllVehiculoEntranceQuery : IRequest<PaginationResult<VehiculoEntranceVM>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetAllVehiculoEntranceQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
