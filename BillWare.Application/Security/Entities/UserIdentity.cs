using Microsoft.AspNetCore.Identity;

namespace BillWare.Security.Entities
{
    public class UserIdentity : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NumberId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public string Role { get; set; } = string.Empty;
    }
}
