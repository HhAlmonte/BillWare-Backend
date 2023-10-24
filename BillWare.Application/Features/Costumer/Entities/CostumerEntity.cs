using BillWare.Application.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace BillWare.Application.Features.Costumer.Entities
{
    public class CostumerEntity : BaseEntity
    {
        [MaxLength(100)] public string FullName { get; set; } = string.Empty;
        [MaxLength(30)] public string? Phone { get; set; }
        [MaxLength(100)] public string? Address { get; set; }
        [MaxLength(13)] public string? NumberId { get; set; }
    }
}
