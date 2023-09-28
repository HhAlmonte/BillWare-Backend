using BillWare.Application.Features.Costumer.Command;
using FluentValidation;

namespace BillWare.Application.Features.Costumer.Validators
{
    public class UpdateCostumerCommandValidator : AbstractValidator<UpdateCostumerCommand>
    {
        public UpdateCostumerCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("{Id} no puede estar en blanco");

            RuleFor(x => x.CreatedAt)
                .NotNull()
                .WithMessage("{CreatedAt} no puede estar en blanco");

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
