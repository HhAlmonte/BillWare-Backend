using AutoMapper;
using BillWare.Application.Features.Account.Command;
using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Security.Entities;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Application.Features.Account.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterUserCommand, ApplicationUser>().ReverseMap();
            CreateMap<AuthResponse, ApplicationUser>().ReverseMap();
            CreateMap<AuthResponse, IdentityUser>().ReverseMap();
        }
    }
}
