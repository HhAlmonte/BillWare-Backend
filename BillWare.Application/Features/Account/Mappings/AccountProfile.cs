using AutoMapper;
using BillWare.Application.Features.Account.Command;
using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Security.Entities;

namespace BillWare.Application.Features.Account.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterUserCommand, UserIdentity>().ReverseMap();
            CreateMap<AuthResponse, UserIdentity>().ReverseMap();
        }
    }
}
