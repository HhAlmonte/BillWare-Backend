using BillWare.Application.Billing.Models;
using BillWare.Application.BillingService.Models;
using FluentValidation;

namespace BillWare.Application.BillingService.Validators
{
    public class BillingServiceValidators : AbstractValidator<BillingServiceRequest>
    {
        public BillingServiceValidators()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
