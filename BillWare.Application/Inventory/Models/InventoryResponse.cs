using BillWare.Application.Category.Models;
using BillWare.Application.Shared.Models;

namespace BillWare.Application.Inventory.Models
{
    public class InventoryResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public CategoryResponse Category { get; set; }
        public string CategoryId { get; set; }
    }
}
