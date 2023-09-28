using BillWare.Application.Features.Costumer.Models;
using MediatR;

namespace BillWare.Application.Features.Costumer.Command
{
    public class CreateCostumerCommand : IRequest<CostumerResponse>
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string NumberId { get; set; } = string.Empty;
    }
}
