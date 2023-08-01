using BillWare.Application.Shared.Models;

namespace BillWare.Application.Billing.Models
{
    public class BillingVM : BaseViewModel
    {
        public string FullName { get; set; }

        public int BillingTypeId { get; set; }
        public BillingTypeVM BillingType { get; set; }

        public List<BillingItemVM> BillingItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
