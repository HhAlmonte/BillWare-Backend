using BillWare.Application.Billing.Entities;
using BillWare.Application.Interfaces;
using BillWare.Application.VehiculoEntrance.Entities;
using BillWare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Repository
{
    public class BillingRepository : BaseCrudRepository<BillingEntity>, IBillingRepository
    {
        private readonly DbSet<BillingEntity> _dbSet;

        public BillingRepository(IBillWareDbContext context) : base(context)
        {
            _dbSet = context.GetDbSet<BillingEntity>();
        }

        public async new Task<PaginationResult<BillingEntity>> Get(int pageIndex, int pageSize)
        {
            var billings = await _dbSet
                .Include(x => x.BillingItems)
                .Include(x => x.BillingType)
                .GetPage(pageIndex, pageSize);

            return billings;
        }
    }
}
