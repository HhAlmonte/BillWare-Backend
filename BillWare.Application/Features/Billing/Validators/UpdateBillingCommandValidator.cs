using BillWare.Application.Features.Billing.Command;
using FluentValidation;

namespace BillWare.Application.Features.Billing.Validators
{
    public class UpdateBillingCommandValidator : AbstractValidator<UpdateBillingCommand>
    {
        public UpdateBillingCommandValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage("{Id} es requerido");

            RuleFor(p => p.SellerName)
                .NotEmpty()
                .WithMessage("{SellerName} no puede estar en blanco");

            RuleFor(p => p.InvoiceNumber)
                .NotEmpty()
                .WithMessage("{InvoiceNumber} no puede estar en blanco");

            RuleFor(p => p.TotalPrice)
                .GreaterThan(0)
                .WithMessage("{TotalPrice} es requerido");

            RuleFor(p => p.TotalPriceWithTax)
                .GreaterThan(0)
                .WithMessage("{TotalPriceWithTax} es requerido");

            RuleFor(p => p.TotalTax)
                .GreaterThan(0)
                .WithMessage("{TotalTax} es requerido");

            RuleFor(p => p.PaymentMethod)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PaymentMethod} no puede estar en blanco");

            RuleFor(p => p.BillingStatus)
                .NotNull()
                .NotEmpty()
                .WithMessage("{BillingStatus} no puede estar en blanco");

            RuleFor(p => p.BillingItems)
                .NotNull()
                .NotEmpty()
                .WithMessage("{BillingItems} no puede estar en blanco");
        }
    }
}
