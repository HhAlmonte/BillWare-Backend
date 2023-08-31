using BillWare.Application.Billing.Models;
using MediatR;

namespace BillWare.Application.Billing.Command
{
    public class UpdateBillingCommand : IRequest<BillingResponse>
    {
        public BillingRequest Request { get; set; }

        public UpdateBillingCommand(BillingRequest request)
        {
            Request = request;
        }
    }
}
