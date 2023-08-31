using BillWare.Application.Billing.Entities;
using BillWare.Application.Shared;

namespace BillWare.Application.Interfaces
{
    public interface IBillingRepository : IBaseCrudRepository<BillingEntity>
    {
        Task<BillingEntity> GetBillingById(int id);

        Task<int> GetInvoiceNumber();
    }
}
