using BillWare.Application.Features.Inventory.Models;
using MediatR;

namespace BillWare.Application.Features.Inventory.Command
{
    public class UpdateInventoryCommand : IRequest<InventoryResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
