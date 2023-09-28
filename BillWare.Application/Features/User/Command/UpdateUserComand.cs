using BillWare.Application.Features.Security.Models;
using MediatR;

namespace BillWare.Application.Features.Security.Command
{
    public class UpdateUserComand : IRequest<UserResponse>
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NumberId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
