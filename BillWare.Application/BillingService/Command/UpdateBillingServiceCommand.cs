using BillWare.Application.Billing.Models;
using BillWare.Application.BillingService.Models;
using MediatR;

namespace BillWare.Application.BillingService.Command
{
    public class UpdateBillingServiceCommand : IRequest<BillingServiceResponse>
    {
        public BillingServiceRequest Request { get; set; }

        public UpdateBillingServiceCommand(BillingServiceRequest request)
        {
            Request = request;
        }
    }
}
