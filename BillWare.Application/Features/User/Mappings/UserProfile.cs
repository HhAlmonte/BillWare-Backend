﻿using AutoMapper;
using BillWare.Application.Features.Security.Command;
using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Features.Security.Models;

namespace BillWare.Application.Features.Security.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserIdentity, UserResponse>();

            CreateMap<UserIdentity, UpdateUserComand>()
                .ReverseMap();

            CreateMap<PaginationResult<UserIdentity>, PaginationResult<UserResponse>>();
        }
    }
}