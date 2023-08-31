using BillWare.Application.Category.Models;
using MediatR;

namespace BillWare.Application.Category.Command
{
    public class UpdateCategoryCommand : IRequest<CategoryResponse>
    {
        public CategoryRequest Request { get; set; }

        public UpdateCategoryCommand(CategoryRequest request)
        {
            Request = request;
        }
    }
}
