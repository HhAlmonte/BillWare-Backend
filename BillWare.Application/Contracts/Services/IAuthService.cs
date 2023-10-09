using BillWare.Application.Features.Security.Entities;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Application.Contracts.Service
{
    public interface IAuthService
    {
        Task<SignInResult> Login(IdentityUser user, string password);
        Task<IdentityResult> Register(IdentityUser user, string password);
    }
}
