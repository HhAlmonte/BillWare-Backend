using BillWare.Application.Billing.Entities;
using BillWare.Application.Interfaces;
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
                .GetPage(pageIndex, pageSize);

            return billings;
        }
    }
}
