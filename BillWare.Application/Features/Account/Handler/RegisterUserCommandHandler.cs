using AutoMapper;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Account.Command;
using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Account.Handler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegistrationResponse>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterUserCommandHandler> _logger;

        public RegisterUserCommandHandler(IAuthService authService,
                                          IUserRepository userRepository,
                                          IMapper mapper,
                                          ILogger<RegisterUserCommandHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _authService = authService;
            _logger = logger;
        }

        public async Task<RegistrationResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetUserByEmail(request.Email);

            if (userExist != null)
            {
                _logger.LogError($"El usuario con correo: {userExist.Email} ya existe");
                throw new ValidationException($"El usuario con correo: {userExist.Email} ya existe");
            }

            var userToCreate = _mapper.Map<UserIdentity>(request);

            userToCreate.EmailConfirmed = true;
            userToCreate.CreatedAt = DateTime.Now;

            var result = await _authService.Register(userToCreate, request.Password);

            if (result.Succeeded)
            {
                await _authService.AddUserToRole(userToCreate, request.Role);

                return new RegistrationResponse
                {
                    UserId = userToCreate.Id,
                    Email = userToCreate.Email ?? "",
                    UserName = userToCreate.UserName ?? "",
                    Token = "El Usuario debe iniciar sesión para obtener el token"
                };
            }

            _logger.LogError($"El usuario con correo: {userToCreate.Email} no pudo ser creado");
            throw new ValidationException($"El usuario con correo: {userToCreate.Email} no pudo ser creado");
        }
    }
}