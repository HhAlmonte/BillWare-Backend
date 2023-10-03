using AutoMapper;
using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Contracts.Service;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Account.Command;
using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Security.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

            var userIdentityToCreate = new IdentityUser
            {
                Email = request.Email,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            var result = await _authService.Register(userIdentityToCreate, request.Password);

            if (result.Succeeded)
            {
                var applicationUser = _mapper.Map<ApplicationUser>(request);

                applicationUser.IdentityId = new Guid(userIdentityToCreate.Id);

                await _authService.AddApplicationUser(applicationUser);

                await _authService.AddUserToRole(userIdentityToCreate, request.Role);

                return new RegistrationResponse
                {
                    UserId = userIdentityToCreate.Id,
                    Email = userIdentityToCreate.Email ?? "",
                    UserName = userIdentityToCreate.UserName ?? "",
                    Token = "El Usuario debe iniciar sesión para obtener el token"
                };
            }

            _logger.LogError($"El usuario con correo: {userIdentityToCreate.Email} no pudo ser creado");
            throw new ValidationException($"El usuario con correo: {userIdentityToCreate.Email} no pudo ser creado");
        }
    }
}