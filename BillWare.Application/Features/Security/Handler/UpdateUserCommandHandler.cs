using AutoMapper;
using BillWare.Application.Features.Security.Command;
using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Features.Security.Models;
using BillWare.Application.Interfaces;
using MediatR;

namespace BillWare.Application.Features.Security.Handler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserComand, UserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Handle(UpdateUserComand request, CancellationToken cancellationToken)
        {
            var userToUpdate = _mapper.Map<UserIdentity>(request.Request);

            var updatedUser = await _userRepository.UpdateUser(userToUpdate);

            return _mapper.Map<UserResponse>(updatedUser);
        }
    }
}
