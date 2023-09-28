using BillWare.Application.Features.Category.Models;
using MediatR;

namespace BillWare.Application.Features.Category.Query
{
    public class GetCategoriesPagedQuery : IRequest<PaginationResult<CategoryResponse>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
