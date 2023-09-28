using BillWare.Application.Features.Service.Command;
using FluentValidation;

namespace BillWare.Application.Features.Service.Validators
{
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{Id} no puede estar en blanco");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{Name} no puede estar en blanco");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("{Description} no puede estar en blanco");
        }
    }
}
