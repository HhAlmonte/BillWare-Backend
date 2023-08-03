using BillWare.Application.Shared.Models;

namespace BillWare.Application.Billing.Models
{
    public class BillingModel : BaseViewModel
    {
        public string FullName { get; set; }

        public List<BillingItemModel> BillingItems { get; set; }

        public int BillingStatus { get; set; }

        public int BillingType { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
