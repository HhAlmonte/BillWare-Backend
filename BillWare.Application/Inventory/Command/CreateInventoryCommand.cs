using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Command
{
    public class CreateInventoryCommand : IRequest<InventoryVM>
    {
        public InventoryCommandModel InventoryCommandModel { get; set; }

        public CreateInventoryCommand(InventoryCommandModel inventoryCommandModel)
        {
            InventoryCommandModel = inventoryCommandModel;
        }
    }
}
