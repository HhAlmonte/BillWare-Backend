namespace BillWare.Application.VehiculoEntrance.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public string Plate { get; set; }
        public string? Comments { get; set; }

        public int VehicleEntranceEntityId { get; set; }
    }
}
