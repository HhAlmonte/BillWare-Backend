using BillWare.Application.User.Command;
using BillWare.Application.User.Models;
using MediatR;

namespace BillWare.Application.User.Handler
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, UserModel>
    {
        public async Task<UserModel> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
