using BillWare.Application.Contracts;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Billing.Models;

namespace BillWare.Application.Interfaces
{
    public interface IBillingRepository : IBaseCrudRepository<BillingEntity>
    {
        Task<BillingEntity> GetBillingById(int id);

        Task<PaginationResult<BillingEntity>> GetBillingsPagedWithParams(ParamsRequest @params);

        Task<int> GetInvoiceNumber();
    }
}
