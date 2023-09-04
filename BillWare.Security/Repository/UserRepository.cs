using BillWare.Application.Interfaces;
using BillWare.Application.Security.Models;
using BillWare.Security.Context;
using BillWare.Security.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Security.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityDbContext _context;

        public UserRepository(SecurityDbContext context)
        {
            _context = context;
        }

        public async Task<PaginationResult<UserIdentity>> GetUsersPaged(int pageIndex, int pageSize)
        {
            var usersPaged = await _context.Users.GetPage(pageIndex, pageSize);

            return usersPaged;
        }

        public Task<PaginationResult<UserIdentity>> GetUsersPagedWithSearch(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }
    }
}
