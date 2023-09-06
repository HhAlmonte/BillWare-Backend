﻿using BillWare.Application.Common.Models;
using BillWare.Application.Shared.Models;

namespace BillWare.Application.Security.Models
{
    public class UserResponse : BaseSecurityResponse
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NumberId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
