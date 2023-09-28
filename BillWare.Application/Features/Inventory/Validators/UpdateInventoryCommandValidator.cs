using BillWare.Application.Features.Inventory.Command;
using FluentValidation;

namespace BillWare.Application.Features.Inventory.Validators
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {
        public UpdateInventoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{Id} no puede estar en blanco");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{Name} no puede estar en blanco")
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("{Description} no puede estar en blanco")
                .MaximumLength(100);

            RuleFor(x => x.Model)
                .NotNull()
                .NotEmpty()
                .WithMessage("{Model} no puede estar en blanco")
                .MaximumLength(100);

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .WithMessage("{Price} no puede estar en blanco");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("{Category} no puede estar en blanco");
        }
    }
}
