using BillWare.Application.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Identity.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRole(string roleName)
        {
            var role = new IdentityRole(roleName);

            var result = await _roleManager.CreateAsync(role);

            return result;
        }

        public async Task<List<IdentityRole>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return roles;
        }

        public async Task<bool> RemoveRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            var result = await _roleManager.DeleteAsync(role!);

            return result.Succeeded;
        }

        public async Task UpdateRole(string roleName, string newRoleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            role!.Name = newRoleName;

            await _roleManager.UpdateAsync(role);
        }
    }
}
