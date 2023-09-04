namespace BillWare.Application.Shared.Models
{
    public class BaseResponse
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
