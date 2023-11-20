using BillWare.Application.Contracts.Service;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Infrastructure.Security.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthService(UserManager<IdentityUser> userManager,
                           SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> Login(IdentityUser user, string password)
        {
            var response = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            return response;
        }

        public async Task<IdentityResult> Register(IdentityUser user, string password)
        {
            var userCreated = await _userManager.CreateAsync(user, password);

            return userCreated;
        }
    }
}
