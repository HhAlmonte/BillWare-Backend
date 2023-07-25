using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("GetCostumersPaged")]
        public async Task<ActionResult<PaginationResult<CostumerVM>>> Get(int pageIndex = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(new GetAllCostumersQuery(pageIndex, pageSize));

            return Ok(result);
        }

        [HttpGet("GetCostumerById/{id}")]
        public async Task<ActionResult<PaginationResult<CostumerVM>>> Get(int id)
        {
            var result = await _mediator.Send(new GetCostumerByIdQuery(id));

            return Ok(result);
        }

        [HttpPost("CreateCostumer")]
        public async Task<ActionResult<CostumerVM>> Post([FromBody] CostumerCommandModel costumer)
        {
            var result = await _mediator.Send(new CreateCostumerCommand(costumer));

            return Ok(result);
        }

        [HttpDelete("DeleteCostumer/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCostumerCommand(id));

            return Ok();
        }

        [HttpPut("UpdateCostumer/{id}")]
        public async Task<ActionResult<CostumerVM>> Put(int id, [FromBody] CostumerCommandModel costumer)
        {
            var result = await _mediator.Send(new UpdateCostumerCommand(id, costumer));

            return Ok(result);
        }
    }
}
