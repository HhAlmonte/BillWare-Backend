using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Query
{
    public class GetVehiculoEntranceWithParamsQuery : IRequest<PaginationResult<VehiculoEntranceVM>>
    {
        public string FullName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetVehiculoEntranceWithParamsQuery(int pageIndex, int pageSize, string fullName)
        {
            FullName = fullName;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
