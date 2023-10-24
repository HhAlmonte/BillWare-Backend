using BillWare.Application.Features.Costumer.Models;
using BillWare.Application.Shared.Models;

namespace BillWare.Application.Features.Billing.Models
{
    public class BillingResponse : BaseResponse
    {
        public CostumerResponse? Costumer { get; set; }

        public string SellerName { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public decimal TotalTax { get; set; }

        public int PaymentMethod { get; set; }
        public int BillingStatus { get; set; }
        public List<BillingItemResponse> BillingItems { get; set; } = new List<BillingItemResponse>();
    }
}
