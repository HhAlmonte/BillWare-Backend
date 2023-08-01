using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Billing.Entities
{
    public class BillingEntity : BaseEntity
    {
        public string FullName { get; set; }

        public int BillingTypeId { get; set; }
        public BillingType BillingType { get; set; }

        public List<BillingItem> BillingItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
