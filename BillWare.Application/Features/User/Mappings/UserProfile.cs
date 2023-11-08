using AutoMapper;
using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Features.Security.Models;

namespace BillWare.Application.Features.Security.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<PaginationResult<ApplicationUser>, PaginationResult<UserResponse>>()
                .ReverseMap();

            CreateMap<ApplicationUser, UserResponse>().ReverseMap();
        }
    }
}
