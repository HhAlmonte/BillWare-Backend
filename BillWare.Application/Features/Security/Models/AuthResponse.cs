using BillWare.Application.Common.Models;
using BillWare.Application.Shared.Models;

namespace BillWare.Application.Features.Security.Models
{
    public class AuthResponse : BaseSecurityResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
