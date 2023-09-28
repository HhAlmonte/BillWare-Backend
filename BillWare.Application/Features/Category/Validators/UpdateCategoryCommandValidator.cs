using BillWare.Application.Features.Category.Command;
using FluentValidation;

namespace BillWare.Application.Features.Category.Validators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("{Id} no puede estar en blanco");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("{Name} no puede estar en blanco");

            RuleFor(x => x.Description)
                        .NotNull()
                        .NotEmpty()
                        .MaximumLength(100)
                        .WithMessage("{Description} no puede estar en blanco");
        }
    }
}
