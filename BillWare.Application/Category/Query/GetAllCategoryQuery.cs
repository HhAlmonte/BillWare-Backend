using BillWare.Application.Category.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillWare.Application.Category.Query
{
    public class GetAllCategoryQuery : IRequest<PaginationResult<CategoryVM>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetAllCategoryQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
