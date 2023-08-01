using BillWare.Application.Shared;
using BillWare.Application.VehiculoEntrance.Entities;

namespace BillWare.Application.Interfaces
{
    public interface IVehicleEntranceRepository : IBaseCrudRepository<VehicleEntranceEntity>
    {
        Task<PaginationResult<VehicleEntranceEntity>> GetWithParams(int pageIndex, int pageSize, string fullName = null);
    }
}
