using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Security.Command;
using BillWare.Application.Features.Security.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Security.Handler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserRepository userRepository, ILogger<DeleteUserCommandHandler> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _userRepository.GetUserById(request.Id);

            if (userToDelete == null)
            {
                _logger.LogError($"{request.Id}, no se encuentra en el sistema.");
                throw new NotFoundException(nameof(ApplicationUser), request.Id);
            }

            var userDeleted = await _userRepository.DeleteUser(userToDelete);
            _logger.LogInformation($"{userToDelete.Id}, eliminado correctamente.");

            return userDeleted;
        }
    }
}
