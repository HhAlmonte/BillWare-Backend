﻿using BillWare.Application.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillWare.Identity.Models
{
    public class RefreshToken : BaseEntity
    {
        public string? UserId { get; set; } = string.Empty;
        public string? Token { get; set; } = string.Empty;
        public string? JwtId { get; set; } = string.Empty;
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime ExpireDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser? User { get; set; }
    }
}