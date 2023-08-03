using BillWare.Application.Shared.Entities;
using BillWare.Application.Shared.Models;

namespace BillWare.Application.Billing.Entities
{
    public class BillingEntity : BaseEntity
    {
        public string FullName { get; set; }

        public BillingStatus BillingStatus { get; set; }

        public BillingTypeEnum BillingType { get; set; }

        public List<BillingItem> BillingItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
