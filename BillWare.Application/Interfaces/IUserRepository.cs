﻿using BillWare.Application.Security.Models;
using BillWare.Security.Entities;

namespace BillWare.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<PaginationResult<UserIdentity>> GetUsersPaged(int pageIndex, int pageSize);

        Task<PaginationResult<UserIdentity>> GetUsersPagedWithSearch(int pageIndex, int pageSize, string search);
    }
}
