using BillWare.Application.Features.Category.Models;
using MediatR;

namespace BillWare.Application.Features.Category.Query
{
    public class GetCategoriesPagedWithSearchQuery : IRequest<PaginationResult<CategoryResponse>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Search { get; set; } = string.Empty;
    }
}
