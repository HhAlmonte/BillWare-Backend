using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Billing.Entities
{
    public class BillingType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
