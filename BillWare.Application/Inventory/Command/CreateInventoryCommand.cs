using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Command
{
    public class CreateInventoryCommand : IRequest<InventoryResponse>
    {
        public InventoryRequest Request { get; set; }

        public CreateInventoryCommand(InventoryRequest request)
        {
            Request = request;
        }
    }
}
