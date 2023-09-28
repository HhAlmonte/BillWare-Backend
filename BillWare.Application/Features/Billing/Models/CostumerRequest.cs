namespace BillWare.Application.Features.Billing.Models
{
    public class CostumerRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? NumberId { get; set; }
    }
}
