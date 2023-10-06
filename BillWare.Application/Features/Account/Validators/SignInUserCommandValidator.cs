using BillWare.Application.Features.Account.Command;
using FluentValidation;

namespace BillWare.Application.Features.Account.Validators
{
    public class SignInUserCommandValidator : AbstractValidator<SignInUserCommand>
    {
        public SignInUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Correo no es válido")
                .NotEmpty()
                .WithMessage("Correo no puede estar en blanco")
                .NotNull()
                .WithMessage("Correo no puede estar en blanco");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Contraseña no puede estar en blanco")
                .NotNull()
                .WithMessage("Contraseña no puede estar en blanco");
        }
    }
}
