using BillWare.Application.Features.Billing.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteBillingItemCommand(id));

            return Ok(response);
        }
    }
}
