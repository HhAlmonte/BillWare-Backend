using BillWare.Application.Inventory.Models;
using MediatR;

namespace BillWare.Application.Inventory.Query
{
    public class GetInventoryByIdQuery : IRequest<InventoryVM>
    {
        public int Id { get; set; }

        public GetInventoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
