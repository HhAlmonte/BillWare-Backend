using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using BillWare.Application.Inventory.Command;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> GetCostumerById(int id)
        {
            var costumer = await _mediator.Send(new GetCostumerByIdQuery(id));

            return Ok(costumer);
        }


        [HttpGet("GetCostumersPagedWithSearch")]
        public async Task<ActionResult<PaginationResult<CostumerResponse>>> GetCostumersPagedWithSearch(string search, int pageIndex, int pageSize)
        {
            var costumers = await _mediator.Send(new GetCostumersPagedWithSearchQuery(pageIndex, pageSize, search));

            return Ok(costumers);
        }

        [HttpGet("GetCostumersPaged")]
        public async Task<ActionResult<PaginationResult<CostumerResponse>>> GetCostumersPaged(int pageIndex, int pageSize)
        {
            var costumers = await _mediator.Send(new GetCostumersPagedQuery(pageIndex, pageSize));

            return Ok(costumers);
        }

        [HttpPost("CreateCostumer")]
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
        public async Task<ActionResult<CostumerResponse>> UpdateCostumer(CostumerRequest request)
        {
            var updatedCostumer = await _mediator.Send(new UpdateCostumerCommand(request));

            return Ok(updatedCostumer);
        }

        [HttpDelete("DeleteCostumer/{id}")]
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
