using BillWare.Application.Features.Account.Models;
using MediatR;

namespace BillWare.Application.Features.Account.Command
{
    public class SignInUserCommand : IRequest<AuthResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
