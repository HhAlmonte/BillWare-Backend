using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Exceptions;
using BillWare.Application.Features.User.Models;
using BillWare.Application.Features.User.Query;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace BillWare.Application.Features.User.Handler
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserAuthResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<GetCurrentUserQueryHandler> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public GetCurrentUserQueryHandler(IUserRepository userRepository, 
                                          ILogger<GetCurrentUserQueryHandler> logger,
                                          UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<UserAuthResponse> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userEmail = request.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            if (!string.IsNullOrEmpty(userEmail))
            {
                var user = await _userRepository.GetUserByEmail(userEmail);

                if(user == null)
                {
                    _logger.LogError("Usuario no encontrado");
                    throw new NotFoundException(nameof(UserAuthResponse), userEmail);
                }

                var userRole = await _userManager.GetRolesAsync(user);

                return new UserAuthResponse
                {
                    IsAuthenticated = request.User.Identity!.IsAuthenticated,
                    Email = userEmail,
                    Name = user.UserName!,
                    Id = user.Id,
                    Role = userRole.FirstOrDefault() ?? "",
                };
            }

            return new UserAuthResponse
            {
                IsAuthenticated = false,
                Email = "N/A",
                Name = "N/A",
            };
        }
    }
}
