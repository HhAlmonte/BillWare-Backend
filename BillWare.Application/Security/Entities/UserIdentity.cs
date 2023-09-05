﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillWare.Security.Entities
{
    public class UserIdentity : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NumberId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        [NotMapped]
        public string Role { get; set; } = string.Empty;
    }
}
