using BillWare.Application.Billing.Entities;
using BillWare.Application.Shared;

namespace BillWare.Application.Interfaces
{
    public interface IBillingRepository : IBaseCrudRepository<BillingEntity>
    {
        Task<BillingEntity> GetBilling(int id);
    }
}
