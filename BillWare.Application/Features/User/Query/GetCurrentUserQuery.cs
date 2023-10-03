using BillWare.Application.Features.User.Models;
using MediatR;
using System.Security.Claims;

namespace BillWare.Application.Features.User.Query
{
    public class GetCurrentUserQuery : IRequest<UserAuthResponse>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
