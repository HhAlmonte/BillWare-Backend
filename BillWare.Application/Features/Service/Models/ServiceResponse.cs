using BillWare.Application.Shared.Models;

namespace BillWare.Application.Features.BillingService.Models
{
    public class ServiceResponse : BaseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
