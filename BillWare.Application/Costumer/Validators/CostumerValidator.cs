using BillWare.Application.Costumer.Entities;
using FluentValidation;

namespace BillWare.Application.Costumer.Validators
{
    public class CostumerValidator : AbstractValidator<CostumerEntity>
    {   
        public CostumerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.TelephoneNumber).NotEmpty().WithMessage("Phone is required");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
        }
    }
}
