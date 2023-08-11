using Microsoft.AspNetCore.Identity;

namespace BillWare.Application.User.Entities
{
    public class UserEntity : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
    }
}
