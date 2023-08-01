using BillWare.Application.Category.Entities;
using BillWare.Application.Category.Models;
using FluentValidation;

namespace BillWare.Application.Category.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryEntity>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required");
        }
    }
}
