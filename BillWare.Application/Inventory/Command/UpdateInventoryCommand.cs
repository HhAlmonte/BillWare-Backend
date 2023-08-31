using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Command
{
    public class UpdateInventoryCommand : IRequest<InventoryResponse>
    {
        public InventoryRequest Request { get; set; }

        public UpdateInventoryCommand(InventoryRequest request)
        {
            Request = request;
        }
    }
}
