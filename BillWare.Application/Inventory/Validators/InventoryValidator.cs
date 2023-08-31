using BillWare.Application.Inventory.Entities;
using BillWare.Application.Inventory.Models;
using FluentValidation;

namespace BillWare.Application.Inventory.Validators
{
    public class InventoryValidator : AbstractValidator<InventoryRequest>
    {
        public InventoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category is required");
        }
    }
}
