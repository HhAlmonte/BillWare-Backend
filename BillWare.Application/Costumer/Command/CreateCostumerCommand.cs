using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class CreateCostumerCommand : IRequest<CostumerVM>
    {
        public CostumerCommandModel CostumerCreate { get; set; }

        public CreateCostumerCommand(CostumerCommandModel costumerCreate)
        {
            CostumerCreate = costumerCreate;
        }
    }
}
