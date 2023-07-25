using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Command
{
    public class UpdateInventoryCommand : IRequest<InventoryVM>
    {
        public InventoryCommandModel InventoryCommandModel { get; set; }
        public int Id { get; set; }

        public UpdateInventoryCommand(InventoryCommandModel inventoryCommandModel, int id)
        {
            InventoryCommandModel = inventoryCommandModel;
            Id = id;
        }
    }
}
