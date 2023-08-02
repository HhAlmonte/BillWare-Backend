using BillWare.Application.Billing.Models;
using MediatR;

namespace BillWare.Application.Billing.Command
{
    public class CreateBillingCommand : IRequest<BillingModel>
    {
        public BillingModel Billing { get; set; }

        public CreateBillingCommand(BillingModel billing)
        {
            Billing = billing;
        }
    }
}
