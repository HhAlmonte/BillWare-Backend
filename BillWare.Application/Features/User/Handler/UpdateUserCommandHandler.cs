using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Security.Command;
using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Features.Security.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Security.Handler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserComand, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UpdateUserComand> _logger;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository,
                                        ILogger<UpdateUserComand> logger,
                                        IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(UpdateUserComand request, CancellationToken cancellationToken)
        {
            var userToUpdate = _userRepository.GetUserById(request.Id);

            if (userToUpdate == null)
            {
                _logger.LogError($"{request.Id}, no se encuentra en el sistema.");
                throw new NotFoundException(nameof(ApplicationUser), request.Id);
            }

            var userMapped = _mapper.Map<IdentityUser>(request);

            var userUpdated = await _userRepository.UpdateUser(userMapped);

            var userResponse = _mapper.Map<UserResponse>(userUpdated);

            _logger.LogInformation($"{userResponse.IdentityId}, actualizado correctamente.");

            return userResponse;
        }
    }
}
