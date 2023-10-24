using BillWare.Application.Common.Enum;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BillWare.Application.Features.Billing.Entities
{
    public class BillingEntity : BaseEntity
    {
        public int CostumerId { get; set; }
        public CostumerEntity? Costumer { get; set; }

        [MaxLength(100)] public string SellerName { get; set; } = string.Empty;
        [MaxLength(100)] public string InvoiceNumber { get; set; } = string.Empty;
        [MaxLength(100)] public decimal TotalPrice { get; set; }
        [MaxLength(100)] public decimal TotalPriceWithTax { get; set; }
        [MaxLength(100)] public decimal TotalTax { get; set; }

        [MaxLength(10)] public PaymentMethod PaymentMethod { get; set; }
        [MaxLength(100)] public BillingStatus BillingStatus { get; set; }

        public List<BillingItemEntity> BillingItems { get; set; } = new List<BillingItemEntity>();
    }
}
