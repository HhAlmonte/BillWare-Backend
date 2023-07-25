using BillWare.Application.Category.Command;
using BillWare.Application.Category.Models;
using BillWare.Application.Category.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) => _mediator = mediator;

        [HttpGet("GetCategoriesPaged")]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoryQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetCategoryById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));

            return Ok(result);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Post([FromBody] CategoryCommandModel command)
        {
            var result = await _mediator.Send(new CreateCategoryCommand(command));

            return Ok(result);
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryCommandModel command)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(id, command));

            return Ok(result);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));

            return Ok(result);
        }
    }
}
