using BillWare.Application.Inventory.Entities;
using BillWare.Application.Shared;

namespace BillWare.Application.Interfaces
{
    public interface IInventoryRepository : IBaseCrudRepository<InventoryEntity>
    {
        Task<bool> UpdateInventoryQuantityAsync(int id, int quantity);
        Task<int> GetCurrentInventoryQuantityByIdAsync(int id);
    }
}
