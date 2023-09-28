namespace BillWare.Application.Features.Billing.Models
{
    public class BillingRequest
    {
        public int Id { get; set; }

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

        public int PaymentMethod { get; set; }
        public int BillingStatus { get; set; }
        public List<BillingItemRequest> BillingItems { get; set; }

        public DateTime CreatedAt { get; set; }

        public string InvoiceDocument { get; set; }
    }
}
