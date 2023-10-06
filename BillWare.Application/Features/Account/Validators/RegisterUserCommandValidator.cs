using BillWare.Application.Features.Account.Command;
using FluentValidation;

namespace BillWare.Application.Features.Account.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("{FirstName} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("{LastName} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("{Email} no puede estar en blanco")
                .NotNull()
                .EmailAddress()
                .WithMessage("{Email} no es válido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("{Password} no puede estar en blanco")
                .NotNull()
                .MinimumLength(6)
                .WithMessage("{Password} debe tener al menos 6 caracteres.")
                .Matches("[A-Z]")
                .WithMessage("{Password} debe contener al menos 1 mayúscula.")
                .Matches("[a-z]")
                .WithMessage("{Password} debe contener al menos 1 minúscula.")
                .Matches("[0-9]")
                .WithMessage("{Password} debe contener al menos 1 número.")
                .Matches("[^a-zA-Z0-9]")
                .WithMessage("{Password} debe contener al menos 1 caracter especial.");

            RuleFor(x => x.NumberId)
                .NotEmpty()
                .WithMessage("{NumberId} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("{Address} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.Role)
                .NotEmpty()
                .WithMessage("{Role} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("{UserName} no puede estar en blanco")
                .NotNull();
        }
    }
}
