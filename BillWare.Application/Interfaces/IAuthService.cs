using BillWare.Application.Security.Models;

namespace BillWare.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
