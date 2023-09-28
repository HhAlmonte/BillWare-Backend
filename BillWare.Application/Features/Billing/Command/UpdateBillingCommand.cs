using BillWare.Application.Features.Billing.Models;
using MediatR;

namespace BillWare.Application.Features.Billing.Command
{
    public class UpdateBillingCommand : IRequest<BillingResponse>
    {
        public BillingRequest Request { get; set; }
        public string InvoiceDocument { get; set; }

        public UpdateBillingCommand(BillingRequest request, string invoiceDocument)
        {
            Request = request;
            InvoiceDocument = invoiceDocument;
        }
    }
}
