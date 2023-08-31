using BillWare.Application.Category.Models;
using MediatR;

namespace BillWare.Application.Category.Command
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public CategoryRequest Request { get; set; }

        public CreateCategoryCommand(CategoryRequest request)
        {
            Request = request;
        }
    }
}
