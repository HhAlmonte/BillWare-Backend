using BillWare.Application.Shared.Models;

namespace BillWare.Application.Costumer.Models
{
    public class CostumerResponse : BaseResponse
    {
        public string FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? NumberId { get; set; }
    }
}
