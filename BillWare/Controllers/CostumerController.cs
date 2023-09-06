using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CostumerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCostumerById")]
        [Authorize]
        public async Task<ActionResult<CostumerResponse>> GetCostumerById(int id)
        {
            try
            {
                var costumer = await _mediator.Send(new GetCostumerByIdQuery(id));

                return Ok(costumer);
            }
            catch (CrudOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetCostumersPagedWithSearch")]
        [Authorize]
        public async Task<ActionResult<PaginationResult<CostumerResponse>>> GetCostumersPagedWithSearch(string search, int pageIndex, int pageSize)
        {
            var costumers = await _mediator.Send(new GetCostumersPagedWithSearchQuery(pageIndex, pageSize, search));

            return Ok(costumers);
        }

        [HttpGet("GetCostumersPaged")]
        [Authorize]
        public async Task<ActionResult<PaginationResult<CostumerResponse>>> GetCostumersPaged(int pageIndex, int pageSize)
        {
            var costumers = await _mediator.Send(new GetCostumersPagedQuery(pageIndex, pageSize));

            return Ok(costumers);
        }

        [HttpPost("CreateCostumer")]
        [Authorize]
        public async Task<ActionResult<CostumerResponse>> CreateCostumer(CostumerRequest request)
        {
            try
            {
                var createdCostumer = await _mediator.Send(new CreateCostumerCommand(request));

                return Ok(createdCostumer);
            }
            catch (CrudOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }
        }

        [HttpPut("UpdateCostumer")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<CostumerResponse>> UpdateCostumer(CostumerRequest request)
        {
            var updatedCostumer = await _mediator.Send(new UpdateCostumerCommand(request));

            return Ok(updatedCostumer);
        }

        [HttpDelete("DeleteCostumer/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteCostumer(int id)
        {
            try
            {
                await _mediator.Send(new DeleteCostumerCommand(id));

                return Ok();
            }
            catch (CrudOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno en el servidor.");
            }
        }
    }
}
