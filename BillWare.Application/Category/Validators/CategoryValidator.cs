using BillWare.Application.Category.Entities;
using FluentValidation;

namespace BillWare.Application.Category.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryEntity>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
