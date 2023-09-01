using BillWare.Application.Billing.Entities;
using BillWare.Application.Billing.Models;
using BillWare.Application.Shared;

namespace BillWare.Application.Interfaces
{
    public interface IBillingRepository : IBaseCrudRepository<BillingEntity>
    {
        Task<BillingEntity> GetBillingById(int id);

        Task<PaginationResult<BillingEntity>> GetBillingsPagedWithParams(ParamsRequest @params);

        Task<int> GetInvoiceNumber();
    }
}
