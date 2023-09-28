using BillWare.Application.Features.Account.Command;
using BillWare.Application.Features.Account.Models;
using BillWare.Application.Features.Costumer.Models;
using BillWare.Application.Features.Security.Models;
using BillWare.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AuthResponse>> Login(SignInUserCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegistrationResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
