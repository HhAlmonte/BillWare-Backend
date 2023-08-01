using BillWare.Application.Category.Models;
using MediatR;

namespace BillWare.Application.Category.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryVM>
    {
        public CategoryCommandModel Category { get; set; }

        public UpdateCategoryCommand(CategoryCommandModel category)
        {
            Category = category;
        }
    }
}
