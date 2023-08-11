using BillWare.Application.User.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Context
{
    public class BillWareSecurityDbContext : IdentityDbContext<UserEntity>
    {
        public BillWareSecurityDbContext(DbContextOptions<BillWareSecurityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
