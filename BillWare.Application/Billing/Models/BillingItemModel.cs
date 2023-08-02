using BillWare.Application.Shared.Models;

namespace BillWare.Application.Billing.Models
{
    public class BillingItemModel : BaseViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}
