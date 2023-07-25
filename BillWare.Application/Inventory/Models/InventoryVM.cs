using BillWare.Application.Category.Models;

namespace BillWare.Application.Inventory.Models
{
    public class InventoryVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryVM Category { get; set; }
    }
}
