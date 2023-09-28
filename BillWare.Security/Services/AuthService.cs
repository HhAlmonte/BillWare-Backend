using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Infrastructure.Security.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly SignInManager<UserIdentity> _signInManager;

        public AuthService(UserManager<UserIdentity> userManager,
                           SignInManager<UserIdentity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(UserIdentity user, string password)
        {
            var response = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            return response;
        }

        public async Task<IdentityResult> Register(UserIdentity user, string password)
        {
            var userCreated = await _userManager.CreateAsync(user, password);

            return userCreated;
        }

        public async Task<IdentityResult> AddUserToRole(UserIdentity user, string role)
        {
            var userRole = await _userManager.AddToRoleAsync(user, role);

            return userRole;
        }
    }
}
