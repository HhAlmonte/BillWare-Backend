using BillWare.Application.Shared.Entities;

namespace BillWare.Application.Features.Category.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
