﻿using BillWare.Application.Inventory.Entities;
using FluentValidation;

namespace BillWare.Application.Inventory.Validators
{
    public class InventoryValidator : AbstractValidator<InventoryEntity>
    {
        public InventoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        }
    }
}
