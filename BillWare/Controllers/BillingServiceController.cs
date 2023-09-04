using BillWare.Application.BillingService.Command;
using BillWare.Application.BillingService.Models;
using BillWare.Application.BillingService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateBillingService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<ActionResult<BillingServiceResponse>> CreateBillingService([FromBody] BillingServiceRequest request)
        {
            var result = await _mediator.Send(new CreateBillingServiceCommand(request));

            return Ok(result);
        }

        [HttpGet("GetBillingsServicesPaged")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<ActionResult<BillingServiceResponse>> GetBillingsServicesPaged(int pageIndex, int pageSize)
        {
            var result = await _mediator.Send(new GetBillingsServicePagedQuery(pageIndex, pageSize));

            return Ok(result);
        }

        [HttpGet("GetBillingsServicesPagedWithSearch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<ActionResult<BillingServiceResponse>> GetBillingsServicesPagedWithSearch(int pageIndex, int pageSize, string search)
        {
            var result = await _mediator.Send(new GetBillingsServicesPagedWithSearchQuery(pageIndex, pageSize, search));

            return Ok(result);
        }

        [HttpPut("UpdateBillingService")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BillingServiceResponse>> UpdateBillingService([FromBody] BillingServiceRequest request)
        {
            var result = await _mediator.Send(new UpdateBillingServiceCommand(request));

            return Ok(result);
        }

        [HttpDelete("DeleteBillingService/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BillingServiceResponse>> DeleteBillingService(int id)
        {
            var result = await _mediator.Send(new DeleteBillingServiceCommand(id));

            return Ok(result);
        }
    }
}
