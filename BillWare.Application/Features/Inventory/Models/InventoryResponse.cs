using BillWare.Application.Features.Category.Models;
using BillWare.Application.Shared.Models;

namespace BillWare.Application.Features.Inventory.Models
{
    public class InventoryResponse : BaseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public CategoryResponse Category { get; set; } = new CategoryResponse();
        public string CategoryId { get; set; } = string.Empty;
    }
}
