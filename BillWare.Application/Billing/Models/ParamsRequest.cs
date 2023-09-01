namespace BillWare.Application.Billing.Models
{
    public class ParamsRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
    }
}
