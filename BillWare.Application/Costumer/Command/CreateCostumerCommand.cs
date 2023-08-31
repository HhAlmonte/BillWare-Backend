using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class CreateCostumerCommand : IRequest<CostumerResponse>
    {
        public CostumerRequest Request { get; set; }

        public CreateCostumerCommand(CostumerRequest request)
        {
            Request = request;
        }
    }
}
