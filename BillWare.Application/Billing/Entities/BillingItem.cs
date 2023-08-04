using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Billing.Entities
{
    public class BillingItem : BaseEntity
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; } = 1;

        public decimal Price { get; set; }
    }
}
