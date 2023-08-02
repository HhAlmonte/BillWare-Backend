using BillWare.Application.Billing.Command;
using BillWare.Application.Billing.Models;
using BillWare.Application.Billing.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IMediator mediator;

        public BillingController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("CreateBilling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBilling([FromBody] BillingModel model)
        {
            try
            {
                var billingCreated = await mediator.Send(new CreateBillingCommand(model));

                return Ok(billingCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBillingsPaged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBillings(int pageIndex, int pageSize)
        {
            try
            {
                var billings = await mediator.Send(new GetBillingsPagedQuery(pageIndex, pageSize));

                return Ok(billings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBilling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBilling(int id)
        {
            try
            {
                await mediator.Send(new DeleteBillingCommand(id));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBilling")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBilling([FromBody] BillingModel model)
        {
            try
            {
                await mediator.Send(new UpdateBillingCommand(model));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
