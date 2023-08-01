using BillWare.Application.Shared.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BillWare.Application.Category.Entities
{
    public class CategoryEntity : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
