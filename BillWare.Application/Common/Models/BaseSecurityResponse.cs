namespace BillWare.Application.Common.Models
{
    public class BaseSecurityResponse
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
