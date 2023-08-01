using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Billing.Entities
{
    public class BillingItem : BaseEntity
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public decimal Price { get; set; }
    }
}
