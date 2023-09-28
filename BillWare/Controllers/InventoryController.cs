using BillWare.Application.Features.Costumer.Models;
using BillWare.Application.Features.Inventory.Command;
using BillWare.Application.Features.Inventory.Models;
using BillWare.Application.Features.Inventory.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [Authorize]
        [HttpGet("GetListPagedWithSearch")]
        [ProducesResponseType(typeof(PaginationResult<InventoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<InventoryResponse>>> GetInventoryWithSearch(string search, int pageIndex, int pageSize)
        {
            var query = new GetInventoriesPagedWithSearchQuery
            {
                Search = search,
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetListPaged")]
        [ProducesResponseType(typeof(PaginationResult<InventoryResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<InventoryResponse>>> GetInventoriesPaged(int pageIndex, int pageSize)
        {
            var query = new GetInventoriesPagedQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("Create")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<InventoryResponse>> CreateInventory(CreateInventoryCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("UpdateInventory")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<InventoryResponse>> UpdateInventory(UpdateInventoryCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("DeleteInventory/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> DeleteInventory(int id)
        {
            var response = await _mediator.Send(new DeleteInventoryCommand(id));

            return Ok(response);
        }
    }
}
