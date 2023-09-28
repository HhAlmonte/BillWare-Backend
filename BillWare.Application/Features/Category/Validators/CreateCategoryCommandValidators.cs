using BillWare.Application.Features.Category.Command;
using FluentValidation;

namespace BillWare.Application.Features.Category.Validators
{
    public class CreateCategoryCommandValidators : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidators()
        {
            RuleFor(x => x.Name)
                        .NotNull()
                        .NotEmpty().WithMessage("{Name} no puede estar en blanco")
                        .MaximumLength(100);

            RuleFor(x => x.Description)
                        .NotNull()
                        .NotEmpty().WithMessage("{Description} no puede estar en blanco")
                        .MaximumLength(100);
        }
    }
}
