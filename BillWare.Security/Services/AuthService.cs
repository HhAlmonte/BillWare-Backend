using BillWare.Application.Contracts.Service;
using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Security.Entities;
using BillWare.Security.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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
