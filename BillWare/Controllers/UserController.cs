using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Security.Command;
using BillWare.Application.Features.Security.Models;
using BillWare.Application.Features.Security.Query;
using BillWare.Application.Features.User.Models;
using BillWare.Application.Features.User.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCurrentUser")]
        [ProducesResponseType(typeof(UserAuthResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserAuthResponse>> GetCurrentUser()
        {
            var query = new GetCurrentUserQuery
            {
                User = User
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("GetListPaged")]
        [ProducesResponseType(typeof(PaginationResult<UserResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<UserResponse>>> GetUsersPaged(int pageIndex, int pageSize)
        {
            var query = new GetUsersPagedQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("Update")]
        [ProducesResponseType(typeof(UserResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserResponse>> UpdateUser(UpdateUserComand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteUser(string id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));

            return Ok(response);
        }
    }
}
