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
                .WithMessage("Nombre no puede estar en blanco")
                .NotNull()
                .WithMessage("Nombre no puede ser nulo");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Descripción no puede estar en blanco")
                .NotNull()
                .WithMessage("Descripción no puede ser nulo");

            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Precio no puede estar en blanco")
                .NotNull()
                .WithMessage("Precio no puede ser nulo");
        }
    }
}
