using BillWare.Application.Interfaces;
using BillWare.Application.Security.Models;
using BillWare.Security.Context;
using BillWare.Security.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> DeleteUser(string id)
        { 
            var userToDelete = await _context.Users.FindAsync(id);

            if (userToDelete == null)
            {
                throw new Exception("User not found");
            }


            await _userManager.DeleteAsync(userToDelete);

            await _context.SaveChangesAsync();

            return true;
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
            var userToUpdate = await _context.Users.FindAsync(user.Id);

            if (userToUpdate == null)
            {
                throw new Exception("User not found");
            }

            var isInRole = await _userManager.IsInRoleAsync(userToUpdate, user.Role);

            if (!isInRole)
            {
                await _userManager.RemoveFromRoleAsync(userToUpdate, userToUpdate.Role);

                await _userManager.AddToRoleAsync(userToUpdate, user.Role);
            }

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.UserName = user.UserName;
            userToUpdate.NumberId = user.NumberId;
            userToUpdate.Address = user.Address;

            await _userManager.UpdateAsync(userToUpdate);

            await _context.SaveChangesAsync();

            return userToUpdate;
        }
    }
}
