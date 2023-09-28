using BillWare.Application.Features.Billing.Models;
using MediatR;

namespace BillWare.Application.Features.Billing.Command
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
