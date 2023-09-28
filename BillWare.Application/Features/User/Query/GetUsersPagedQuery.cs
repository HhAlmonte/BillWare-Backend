using BillWare.Application.Features.Security.Models;
using MediatR;

namespace BillWare.Application.Features.Security.Query
{
    public class GetUsersPagedQuery : IRequest<PaginationResult<UserResponse>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
