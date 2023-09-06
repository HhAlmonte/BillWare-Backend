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

        [Authorize]
        [HttpPost("CreateBillingService")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<BillingServiceResponse>> CreateBillingService([FromBody] BillingServiceRequest request)
        {
            try
            {
                var content = await _mediator.Send(new CreateBillingServiceCommand(request));

                return Ok(content);
            }
            catch (CrudOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetBillingsServicesPaged")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<BillingServiceResponse>> GetBillingsServicesPaged(int pageIndex, int pageSize)
        {
            try
            {
                var content = await _mediator.Send(new GetBillingsServicePagedQuery(pageIndex, pageSize));

                return Ok(content);
            }
            catch (CrudOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetBillingsServicesPagedWithSearch")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<BillingServiceResponse>> GetBillingsServicesPagedWithSearch(int pageIndex, int pageSize, string search)
        {
            var content = await _mediator.Send(new GetBillingsServicesPagedWithSearchQuery(pageIndex, pageSize, search));

            return Ok(content);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("UpdateBillingService")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<BillingServiceResponse>> UpdateBillingService([FromBody] BillingServiceRequest request)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Unauthorized("Este usuario no esté autorizado para acción");
            }

            try
            {
                var content = await _mediator.Send(new UpdateBillingServiceCommand(request));

                return Ok(content);
            }
            catch (CrudOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("DeleteBillingService/{id}")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<BillingServiceResponse>> DeleteBillingService(int id)
        {
            if (!User.IsInRole("Administrator"))
            {
                return Unauthorized("Este usuario no esté autorizado para acción");
            }

            try
            {
                var content = await _mediator.Send(new DeleteBillingServiceCommand(id));

                return Ok(content);
            }
            catch (CrudOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
