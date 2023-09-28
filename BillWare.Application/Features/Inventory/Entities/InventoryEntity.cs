using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Features.Inventory.Entities
{
    public class InventoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
