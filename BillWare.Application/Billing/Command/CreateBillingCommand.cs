using BillWare.Application.Billing.Models;
using MediatR;

namespace BillWare.Application.Billing.Command
{
    public class CreateBillingCommand : IRequest<BillingResponse>
    {
        public BillingRequest Request { get; set; }

        public CreateBillingCommand(BillingRequest request)
        {
            Request = request;
        }
    }
}
