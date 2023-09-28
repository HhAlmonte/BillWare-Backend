using BillWare.Application.Features.Category.Entities;
using BillWare.Application.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BillWare.Application.Features.Inventory.Entities
{
    public class InventoryEntity : BaseEntity
    {
        [MaxLength(100)] public string Name { get; set; } = string.Empty;
        [MaxLength(100)] public string Description { get; set; } = string.Empty;
        [MaxLength(100)] public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = new CategoryEntity();
    }
}
