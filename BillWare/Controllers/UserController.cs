using BillWare.Application.Security.Models;
using BillWare.Application.Security.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetUsersPaged")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginationResult<UserResponse>>> GetUsersPaged([FromQuery] int pageIndex, int pageSize)
        {
            var response = await mediator.Send(new GetUsersPagedQuery(pageIndex, pageSize));

            return Ok(response);
        }
    }
}
