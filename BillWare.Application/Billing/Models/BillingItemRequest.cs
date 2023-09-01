namespace BillWare.Application.Billing.Models
{
    public class BillingItemRequest
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
