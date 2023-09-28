using BillWare.Application.Features.Security.Entities;

namespace BillWare.Application.Contracts
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserIdentity user);
    }
}
