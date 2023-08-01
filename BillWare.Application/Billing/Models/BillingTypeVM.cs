using BillWare.Application.Shared.Models;

namespace BillWare.Application.Billing.Models
{
    public class BillingTypeVM : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
