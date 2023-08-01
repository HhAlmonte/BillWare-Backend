using BillWare.Application.Shared.Models;

namespace BillWare.Application.Inventory.Models
{
    public class InventoryCommandModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
