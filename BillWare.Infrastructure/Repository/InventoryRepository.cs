using BillWare.Application.Interfaces;
using BillWare.Application.Inventory.Entities;
using BillWare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Repository
{
    public class InventoryRepository : BaseCrudRepository<InventoryEntity>, IInventoryRepository
    {
        private readonly IBillWareDbContext _context;
        private readonly DbSet<InventoryEntity> _dbSet;

        public InventoryRepository(BillWareDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.GetDbSet<InventoryEntity>();
        }

        public async Task<int> GetCurrentQuantity(int id)
        {
            var inventory = await _dbSet.FindAsync(id);
            if (inventory == null)
                return 0;

            return inventory.Quantity;
        }

        public async Task<bool> UpdateQuantity(int id, int quantity)
        {
            var inventory = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (inventory == null) return false;

            inventory.Quantity = quantity;

            await Update(inventory);

            return true;
        }
    }
}
