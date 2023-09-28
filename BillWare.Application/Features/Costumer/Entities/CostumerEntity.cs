using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Features.Costumer.Entities
{
    public class CostumerEntity : BaseEntity
    {
        public string FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? NumberId { get; set; }
    }
}
