using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;
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

        public async Task<PaginationResult<BillingEntity>> GetBillingsPagedWithParams(ParamsRequest @params)
        {
            var billings = _dbSet
                .Include(x => x.BillingItems)
                .AsQueryable();

            if(@params.InitialDate != null && @params.FinalDate != null)
            {
                billings = billings.Where(x => x.CreatedAt.Date >= @params.InitialDate.Value.Date && x.CreatedAt.Date <= @params.FinalDate.Value.Date);
            }

            var billingsReponse = await billings
                .GetPage(@params.PageIndex, @params.PageSize);

            return billingsReponse;
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
                .OrderByDescending(x => x.CreatedAt)
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
