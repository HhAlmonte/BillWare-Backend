using BillWare.Application.Interfaces;
using BillWare.Application.Security.Command;
using MediatR;

namespace BillWare.Application.Security.Handler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteUser(request.Id);
        }
    }
}
