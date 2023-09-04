using AutoMapper;
using BillWare.Application.Security.Models;
using BillWare.Security.Entities;

namespace BillWare.Application.Security.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserIdentity, UserResponse>();
            CreateMap<PaginationResult<UserIdentity>, PaginationResult<UserResponse>>();
        }
    }
}
