using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Query
{
    public class GetVehiclesEntrancePagedQuery : IRequest<PaginationResult<VehiculoEntranceVM>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetVehiclesEntrancePagedQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
