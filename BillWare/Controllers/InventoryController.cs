using BillWare.Application.Inventory.Command;
using BillWare.Application.Inventory.Models;
using BillWare.Application.Inventory.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetInventoryById/{id}")]
        public async Task<ActionResult<InventoryVM>> GetInventoryById(int id)
        {
            var inventory = await _mediator.Send(new GetInventoryByIdQuery(id));

            return Ok(inventory);
        }

        [HttpGet("GetInventoriesPaged")]
        public async Task<ActionResult<PaginationResult<InventoryVM>>> GetInventoriesPaged(int page, int pageSize)
        {
            var inventories = await _mediator.Send(new GetAllInventoryQuery(page, pageSize));

            return Ok(inventories);
        }

        [HttpPost("CreateInventory")]
        public async Task<ActionResult<InventoryVM>> CreateInventory(InventoryCommandModel inventory)
        {
            var createdInventory = await _mediator.Send(new CreateInventoryCommand(inventory));

            return Ok(createdInventory);
        }

        [HttpPut("UpdateInventory/{id}")]
        public async Task<ActionResult<InventoryVM>> UpdateInventory(int id, InventoryCommandModel inventory)
        {
            var updatedInventory = await _mediator.Send(new UpdateInventoryCommand(inventory, id));

            return Ok(updatedInventory);
        }

        [HttpDelete("DeleteInventory/{id}")]
        public async Task<ActionResult> DeleteInventory(int id)
        {
            await _mediator.Send(new DeleteInventoryCommand(id));

            return Ok();
        }
    }
}
