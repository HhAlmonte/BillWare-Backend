using BillWare.Application.Features.Security.Entities;
using BillWare.Application.Interfaces;
using BillWare.Security.Context;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Infrastructure.Security.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityDbContext _context;
        private readonly UserManager<UserIdentity> _userManager;

        public UserRepository(SecurityDbContext context, UserManager<UserIdentity> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> DeleteUser(UserIdentity user)
        {
            await _userManager.DeleteAsync(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UserIdentity> GetUserById(string id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<UserIdentity> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
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

        public async Task<UserIdentity> UpdateUser(UserIdentity user)
        {
            await _userManager.UpdateAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
