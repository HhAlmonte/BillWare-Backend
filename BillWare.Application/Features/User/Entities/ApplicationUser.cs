using BillWare.Application.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BillWare.Application.Features.Security.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public Guid IdentityId { get; set; }

        [MaxLength(100)] public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)] public string LastName { get; set; } = string.Empty;
        [MaxLength(11)] public string NumberId { get; set; } = string.Empty;
        [MaxLength(100)] public string Address { get; set; } = string.Empty;
        [MaxLength(20)] public string Role { get; set; } = string.Empty;
        [MaxLength(100)] public string Email { get; set; } = string.Empty;
    }
}
