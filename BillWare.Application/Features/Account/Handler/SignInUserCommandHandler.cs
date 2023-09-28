using AutoMapper;
using BillWare.Application.Contracts;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.Account.Command;
using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BillWare.Application.Features.Account.Handler
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, AuthResponse>
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<SignInUserCommandHandler> _logger;
        private readonly UserManager<UserIdentity> _userManager;

        public SignInUserCommandHandler(IAuthService authService, 
                                        IMapper mapper, 
                                        IUserRepository userRepository, 
                                        ITokenService tokenService,
                                        UserManager<UserIdentity> userManager,
                                        ILogger<SignInUserCommandHandler> logger)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _authService = authService;
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<AuthResponse> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetUserByEmail(request.Email);

            if (existingUser == null)
            {
                _logger.LogError($"El usuario con Email {request.Email} no existe");
                throw new NotFoundException(nameof(AuthRequest), existingUser.Email);
            }

            var authResponse = await _authService.Login(existingUser, request.Password);

            if (authResponse.Succeeded)
            {
                var userRole = await _userManager.GetRolesAsync(existingUser);

                var authResponseMapped = _mapper.Map<AuthResponse>(existingUser);
                authResponseMapped.Role = userRole.FirstOrDefault() ?? "";
                authResponseMapped.Token = await _tokenService.GenerateToken(existingUser);

                _logger.LogInformation($"El usuario {existingUser.Email} se ha logueado correctamente");

                return authResponseMapped;
            }

            _logger.LogError($"El usuario {existingUser.Email} no se ha logueado correctamente");
            throw new BadRequestException("Usuario o contraseña incorrectos");
        }
    }
}
