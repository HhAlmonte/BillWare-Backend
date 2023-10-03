using BillWare.Application.Features.Security.Entities;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<PaginationResult<IdentityUser>> GetUsersPaged(int pageIndex, int pageSize);

        Task<PaginationResult<IdentityUser>> GetUsersPagedWithSearch(int pageIndex, int pageSize, string search);

        Task<IdentityUser> UpdateUser(IdentityUser user);

        Task<IdentityUser> GetUserById(string id);

        Task<IdentityUser> GetUserByEmail(string email);

        Task<bool> DeleteUser(IdentityUser user);
    }
}
