using BillWare.Application.Features.Costumer.Command;
using FluentValidation;

namespace BillWare.Application.Features.Costumer.Validators
{
    public class CreateCostumerCommandValidator : AbstractValidator<CreateCostumerCommand>
    {
        public CreateCostumerCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{FullName} no puede estar en blanco");

            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .WithMessage("{Address} no puede estar en blanco");

            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("{Phone} no puede estar en blanco");

            RuleFor(x => x.NumberId)
                .NotNull()
                .NotEmpty()
                .WithMessage("{NumberId} no puede estar en blanco");
        }
    }
}
