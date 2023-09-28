using BillWare.Application.Features.BillingService.Models;
using MediatR;

namespace BillWare.Application.Features.BillingService.Command
{
    public class CreateServiceCommand : IRequest<ServiceResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
