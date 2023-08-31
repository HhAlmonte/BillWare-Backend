using BillWare.Application.Category.Models;
using FluentValidation;

namespace BillWare.Application.Category.Validators
{
    public class CategoryValidators : AbstractValidator<CategoryRequest>
    {
        public CategoryValidators() 
        { 
        }
    }
}
