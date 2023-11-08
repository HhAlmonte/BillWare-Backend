using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.BillingService.Entities;
using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Features.Costumer.Entities;
using BillWare.Application.Features.Inventory.Entities;
using BillWare.Application.Shared.Entities;
using BillWare.Infrastructure.Context.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Context
{
    public interface IBillWareDbContext : IDisposable
    {
        public DbSet<T> GetDbSet<T>() where T : BaseEntity;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class BillWareDbContext : DbContext, IBillWareDbContext
    {
        public BillWareDbContext(DbContextOptions<BillWareDbContext> options) : base(options)
        {
        }


        public DbSet<CostumerEntity> Costumers { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
        public DbSet<ServiceEntity> BillingService { get; set; }
        public DbSet<BillingEntity> Billings { get; set; }
        public DbSet<BillingItemEntity> BillingItems { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(type.ClrType))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }

        public void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }

                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.Now;
                    entry.State = EntityState.Modified;
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<T> GetDbSet<T>() where T : BaseEntity => Set<T>();
    }
}
