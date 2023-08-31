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

        public async Task<BillingEntity> GetBillingById(int id)
        {
            var billing = await _dbSet
                .Include(x => x.BillingItems)
                .FirstOrDefaultAsync(x => x.Id == id);

            return billing;
        }

        public async new Task<PaginationResult<BillingEntity>> GetEntitiesPaged(int pageIndex, int pageSize)
        {
            var billings = await _dbSet
                .Include(x => x.BillingItems)
                .GetPage(pageIndex, pageSize);

            return billings;
        }

        public async Task<int> GetInvoiceNumber()
        {
            var lastInvoiceNumber = await _dbSet.OrderBy(x => x.Id).LastAsync();

            return lastInvoiceNumber.Id;
        }
    }
}
