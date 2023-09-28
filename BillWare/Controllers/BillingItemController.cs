using BillWare.Application.Features.Billing.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingItemController : ControllerBase
    {
        private readonly IMediator mediator;

        public BillingItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpDelete("DeleteBillingItem")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await mediator.Send(new DeleteBillingItemCommand(id));

            return Ok(request);
        }
    }
}
