using BillWare.Application.Billing.Models;
using BillWare.Application.BillingService.Models;
using MediatR;

namespace BillWare.Application.BillingService.Command
{
    public class CreateBillingServiceCommand : IRequest<BillingServiceResponse>
    {
        public BillingServiceRequest Request { get; set; }

        public CreateBillingServiceCommand(BillingServiceRequest request)
        {
            Request = request;
        }
    }
}
