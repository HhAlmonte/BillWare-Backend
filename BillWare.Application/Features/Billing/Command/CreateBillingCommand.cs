using BillWare.Application.Common.Enum;
using BillWare.Application.Features.Billing.Models;
using MediatR;

namespace BillWare.Application.Features.Billing.Command
{
    public class CreateBillingCommand : IRequest<BillingResponse>
    {
        public int CostumerId { get; set; }
        public string SellerName { get; set; } = string.Empty;
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithTax { get; set; }
        public decimal TotalTax { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public BillingStatus BillingStatus { get; set; }
        public List<BillingItemRequest> BillingItems { get; set; } = new List<BillingItemRequest>();

        public string? InvoiceHtmlContent { get; set; } = string.Empty;
    }
}


