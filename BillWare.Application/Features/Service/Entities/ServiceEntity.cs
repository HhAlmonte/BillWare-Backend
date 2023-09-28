using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Features.BillingService.Entities
{
    public class ServiceEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
