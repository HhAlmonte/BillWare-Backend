using BillWare.Application.Shared.Models;

namespace BillWare.Application.Costumer.Models
{
    public class CostumerVM : BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
    }
}
