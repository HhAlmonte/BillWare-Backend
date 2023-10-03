using BillWare.Application.Features.Account.Models;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Application.Contracts.Service
{
    public interface ITokenService
    {
        Task<Tuple<string, string>> GenerateToken(IdentityUser user);
        Task<AuthResponse> RefreshToken(TokenRequest tokenRequest);
    }
}
