using BillWare.Application.Inventory.Command;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetInventoryWithSearch")]
        public async Task<ActionResult<PaginationResult<InventoryResponse>>> GetInventoryWithSearch(string search, int pageIndex, int pageSize)
        {
            var inventory = await _mediator.Send(new GetInventoriesPagedWithSearchQuery(search, pageIndex, pageSize));

            return Ok(inventory);
        }

        [HttpGet("GetInventoriesPaged")]
        public async Task<ActionResult<PaginationResult<InventoryResponse>>> GetInventoriesPaged(int pageIndex, int pageSize)
        {
            var inventories = await _mediator.Send(new GetInventoriesPagedQuery(pageIndex, pageSize));

            return Ok(inventories);
        }

        [HttpPost("CreateInventory")]
        public async Task<ActionResult<InventoryResponse>> CreateInventory(InventoryRequest inventory)
        {
            try
            {
                var createdInventory = await _mediator.Send(new CreateInventoryCommand(inventory));

                return Ok(createdInventory);
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

        [HttpPut("UpdateInventory")]
        public async Task<ActionResult<InventoryResponse>> UpdateInventory(InventoryRequest inventory)
        {
            var updatedInventory = await _mediator.Send(new UpdateInventoryCommand(inventory));

            return Ok(updatedInventory);
        }

        [HttpDelete("DeleteInventory/{id}")]
        public async Task<ActionResult> DeleteInventory(int id)
        {
            try
            {
                await _mediator.Send(new DeleteInventoryCommand(id));

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
