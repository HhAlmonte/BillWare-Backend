using BillWare.Application.Shared.Models;

namespace BillWare.Application.BillingService.Models
{
    public class BillingServiceResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
