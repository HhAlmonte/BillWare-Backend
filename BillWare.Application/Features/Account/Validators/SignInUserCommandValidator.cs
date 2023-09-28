using BillWare.Application.Features.Account.Command;
using FluentValidation;

namespace BillWare.Application.Features.Account.Validators
{
    public class SignInUserCommandValidator : AbstractValidator<SignInUserCommand>
    {
        public SignInUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{Email} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{Password} no puede estar en blanco")
                .NotNull();
        }
    }
}
