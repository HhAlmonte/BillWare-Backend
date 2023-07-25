using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class UpdateCostumerCommand : IRequest<CostumerVM>
    {
        public int Id { get; set; }
        public CostumerCommandModel CostumerUpdate { get; set; }

        public UpdateCostumerCommand(int id, CostumerCommandModel costumerUpdate)
        {
            Id = id;
            CostumerUpdate = costumerUpdate;
        }
    }
}
