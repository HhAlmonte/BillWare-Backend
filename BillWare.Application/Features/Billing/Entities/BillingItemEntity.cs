using BillWare.Application.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BillWare.Application.Features.Billing.Entities
{
    public class BillingItemEntity : BaseEntity
    {
        public int Code { get; set; }
        [MaxLength(100)] public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
        public int BillingId { get; set; }
        public BillingEntity Billing { get; set; } = new BillingEntity();
    }
}
