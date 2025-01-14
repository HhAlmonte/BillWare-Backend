﻿using BillWare.Application.Features.Account.Models;
using MediatR;

namespace BillWare.Application.Features.Account.Command
{
    public class RegisterUserCommand : IRequest<RegistrationResponse>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string NumberId { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
