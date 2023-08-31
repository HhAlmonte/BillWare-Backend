using BillWare.Application.Costumer.Models;
using FluentValidation;

namespace BillWare.Application.Costumer.Validators
{
    public class CostumerValidator : AbstractValidator<CostumerRequest>
    {
        public CostumerValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty();
            RuleFor(x => x.Address).NotNull().NotEmpty();
            RuleFor(x => x.Phone).NotNull().NotEmpty();
            RuleFor(x => x.NumberId).NotNull().NotEmpty();
        }
    }
}
