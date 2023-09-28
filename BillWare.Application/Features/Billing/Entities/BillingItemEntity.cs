using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Features.Billing.Entities
{
    public class BillingItemEntity : BaseEntity
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }


        public int BillingId { get; set; }
        public BillingEntity Billing { get; set; }
    }
}
