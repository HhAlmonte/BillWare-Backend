using BillWare.Application.Features.Security.Command;
using FluentValidation;

namespace BillWare.Application.Features.User.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserComand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("{Id} no puede estar en blanco")   
                .NotNull();

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("{UserName} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("{Email} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("{FirstName} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("{LastName} no puede estar en blanco")
                .NotNull();

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
        }
    }
}
