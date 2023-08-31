using BillWare.Application.Costumer.Models;
using MediatR;

namespace BillWare.Application.Costumer.Command
{
    public class UpdateCostumerCommand : IRequest<CostumerResponse>
    {
        public CostumerRequest Request { get; set; }

        public UpdateCostumerCommand(CostumerRequest request)
        {
            Request = request;
        }
    }
}
