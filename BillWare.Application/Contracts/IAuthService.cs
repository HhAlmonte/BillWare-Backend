using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Security.Entities;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Application.Interfaces
{
    public interface IAuthService
    {
        Task<SignInResult> Login(UserIdentity user, string password);
        Task<IdentityResult> Register(UserIdentity user, string password);
        Task<IdentityResult> AddUserToRole(UserIdentity user, string role);
    }
}
