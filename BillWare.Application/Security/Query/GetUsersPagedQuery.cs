using BillWare.Application.Security.Models;
using MediatR;

namespace BillWare.Application.Security.Query
{
    public class GetUsersPagedQuery : IRequest<PaginationResult<UserResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public GetUsersPagedQuery(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
