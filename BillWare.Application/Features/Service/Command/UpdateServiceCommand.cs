using BillWare.Application.Features.BillingService.Models;
using MediatR;

namespace BillWare.Application.Features.Service.Command
{
    public class UpdateServiceCommand : IRequest<ServiceResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

