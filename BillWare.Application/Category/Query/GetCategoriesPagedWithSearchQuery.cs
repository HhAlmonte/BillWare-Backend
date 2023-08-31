using BillWare.Application.Category.Models;
using MediatR;

namespace BillWare.Application.Category.Query
{
    public class GetCategoriesPagedWithSearchQuery : IRequest<PaginationResult<CategoryResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }

        public GetCategoriesPagedWithSearchQuery(int pageIndex, int pageSize, string search)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Search = search;
        }
    }
}
