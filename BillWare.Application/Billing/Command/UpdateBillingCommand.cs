using BillWare.Application.Billing.Models;
using MediatR;

namespace BillWare.Application.Billing.Command
{
    public class UpdateBillingCommand : IRequest<BillingModel>
    {
        public BillingModel Billing { get; set; }

        public UpdateBillingCommand(BillingModel billing)
        {
            Billing = billing;
        }
    }
}
