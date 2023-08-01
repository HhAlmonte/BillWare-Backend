using BillWare.Application.Category.Models;
using MediatR;

namespace BillWare.Application.Category.Query
{
    public class GetCategoryWithSearchQuery : IRequest<PaginationResult<CategoryVM>>
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetCategoryWithSearchQuery(string search, int pageIndex, int pageSize)
        {
            Search = search;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
