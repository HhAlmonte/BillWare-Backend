using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BillWare.Application.Features.Security.Entities
{
    public class UserIdentity : IdentityUser
    {
        [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)] public string LastName { get; set; } = string.Empty;
        [MaxLength(11)] public string NumberId { get; set; } = string.Empty;
        [MaxLength(100)] public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        [MaxLength(20)] public string Role { get; set; } = string.Empty;
    }
}
