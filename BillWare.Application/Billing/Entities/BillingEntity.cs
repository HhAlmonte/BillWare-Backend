using BillWare.Application.Shared.Entities;
using BillWare.Application.Shared.Models;

namespace BillWare.Application.Billing.Entities
{
    public class BillingEntity : BaseEntity
    {
        // Costumer
        public string FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? NumberId { get; set; }

        // Billing
        public string SellerName { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public decimal TotalTax { get; set; }

        public BillingStatus BillingStatus { get; set; }
        public List<BillingItemEntity> BillingItems { get; set; }
    }
}
