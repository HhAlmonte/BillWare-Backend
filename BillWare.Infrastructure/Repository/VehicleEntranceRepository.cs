using BillWare.Application.Interfaces;
using BillWare.Application.VehiculoEntrance.Entities;
using BillWare.Infrastructure.Context;
using BillWare.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Application.Repositories
{
    public class VehicleEntranceRepository : BaseCrudRepository<VehicleEntranceEntity>, IVehicleEntranceRepository 
    {
        private readonly DbSet<VehicleEntranceEntity> _dbSet;

        public VehicleEntranceRepository(IBillWareDbContext context) : base(context)
        {
            _dbSet = context.GetDbSet<VehicleEntranceEntity>();
        }

        public async new Task<PaginationResult<VehicleEntranceEntity>> Get(int pageIndex, int pageSize)
        {
            var entityList = await _dbSet
                .Include(entity => entity.Costumer)
                .Include(entity => entity.Vehicles)
                .GetPage(pageIndex, pageSize);

            return entityList;
        }

        public async Task<PaginationResult<VehicleEntranceEntity>> GetWithParams(int pageIndex, int pageSize, string fullName = null)
        {
            var resultToReturn = await _dbSet
                .Include(entity => entity.Costumer)
                .Include(entity => entity.Vehicles)
                .Where(entity => entity.Costumer.FullName.Contains(fullName))
                .GetPage(pageIndex, pageSize);

            return resultToReturn;
        }
    }
}
