using BillWare.Application.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BillWare.Application.Features.BillingService.Entities
{
    public class ServiceEntity : BaseEntity
    {
        [MaxLength(100)] public string Name { get; set; } = string.Empty;
        [MaxLength(100)] public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
