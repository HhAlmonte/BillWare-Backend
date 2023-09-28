using BillWare.Application.Features.BillingService.Command;
using FluentValidation;

namespace BillWare.Application.Features.BillingService.Validators
{
    public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{Name} no puede estar en blanco");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("{Description} no puede estar en blanco");
        }
    }
}
