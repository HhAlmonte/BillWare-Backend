using BillWare.Application.Features.Costumer.Models;
using MediatR;

namespace BillWare.Application.Features.Costumer.Command
{
    public class UpdateCostumerCommand : IRequest<CostumerResponse>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string NumberId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
