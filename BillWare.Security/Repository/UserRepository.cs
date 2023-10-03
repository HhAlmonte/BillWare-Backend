using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Security.Entities;
using BillWare.Security.Context;
using Microsoft.AspNetCore.Identity;

namespace BillWare.Infrastructure.Security.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SecurityDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(SecurityDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> DeleteUser(IdentityUser user)
        {
            await _userManager.DeleteAsync(user);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IdentityUser> GetUserById(string id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        public async Task<IdentityUser> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<PaginationResult<IdentityUser>> GetUsersPaged(int pageIndex, int pageSize)
        {
            var usersPaged = await _context.Users.GetPage(pageIndex, pageSize);

            return usersPaged;
        }

        public Task<PaginationResult<IdentityUser>> GetUsersPagedWithSearch(int pageIndex, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> UpdateUser(IdentityUser user)
        {
            await _userManager.UpdateAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
