using BillWare.Application.Inventory.Entities;
using BillWare.Application.Shared;

namespace BillWare.Application.Interfaces
{
    public interface IInventoryRepository : IBaseCrudRepository<InventoryEntity>
    {
        Task<bool> UpdateQuantity(int id, int quantity);
        Task<int> GetCurrentQuantity(int id);
    }
}
