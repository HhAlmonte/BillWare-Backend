using Microsoft.AspNetCore.Identity;

namespace BillWare.Application.Contracts.Repositories
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateRole(string roleName);
        Task<List<IdentityRole>> GetRoles();
        Task<bool> RemoveRole(string roleName);
        Task UpdateRole(string roleName, string newRoleName);
    }
}
