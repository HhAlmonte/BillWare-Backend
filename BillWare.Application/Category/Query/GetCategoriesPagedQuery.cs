using BillWare.Application.Category.Models;
using MediatR;

namespace BillWare.Application.Category.Query
{
    public class GetCategoriesPagedQuery : IRequest<PaginationResult<CategoryResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetCategoriesPagedQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
