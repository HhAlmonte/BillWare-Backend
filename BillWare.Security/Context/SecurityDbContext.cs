using BillWare.Infrastructure.Security.Configurations;
using BillWare.Security.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Security.Context
{
    public class SecurityDbContext : IdentityDbContext<UserIdentity>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
