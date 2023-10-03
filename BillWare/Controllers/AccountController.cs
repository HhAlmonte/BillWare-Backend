using BillWare.Application.Contracts.Service;
using BillWare.Application.Features.Account.Command;
using BillWare.Application.Features.Account.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public AccountController(IMediator mediator, ITokenService tokenService)
        {
            _tokenService = tokenService;
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

       /* [Authorize(Roles = "Administrator")]*/
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegistrationResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RegistrationResponse>> Register(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize]
        [HttpPost("refres-token")]
        [ProducesResponseType(typeof(RegistrationResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<RegistrationResponse>> RefreshToken(TokenRequest tokenRequest)
        {
            var response = await _tokenService.RefreshToken(tokenRequest);

            return Ok(response);
        }
    }
}
