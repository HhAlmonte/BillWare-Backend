using BillWare.Application.Features.Inventory.Entities;

namespace BillWare.Application.Contracts.Persistence
{
    public interface IInventoryRepository : IBaseCrudRepository<InventoryEntity>
    {
        Task<bool> UpdateInventoryQuantityAsync(int id, int quantity);
        Task<int> GetCurrentInventoryQuantityByIdAsync(int id);
    }
}
