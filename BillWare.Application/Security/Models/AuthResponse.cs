using BillWare.Application.Shared.Models;

namespace BillWare.Application.Security.Models
{
    public class AuthResponse : BaseResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
