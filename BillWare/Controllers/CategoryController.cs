using BillWare.Application.Category.Command;
using BillWare.Application.Category.Models;
using BillWare.Application.Category.Query;
using FluentValidation;
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
        public async Task<IActionResult> Get(int pageIndex, int pageSize = 5)
        {
            var result = await _mediator.Send(new GetAllCategoryQuery(pageIndex, pageSize));

            return Ok(result);
        }

        [HttpGet("GetCategoryWithSearch")]
        public async Task<IActionResult> Get(string search, int pageIndex, int pageSize)
        {
            var result = await _mediator.Send(new GetCategoryWithSearchQuery(search, pageIndex, pageSize));

            return Ok(result);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> Post([FromBody] CategoryCommandModel command)
        {
            try
            {
                var result = await _mediator.Send(new CreateCategoryCommand(command));

                return Ok(result);
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
                return StatusCode(500, "Error interno en el servidor.");
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> Put([FromBody] CategoryCommandModel command)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(command));

            return Ok(result);
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCategoryCommand(id));

                return Ok(result);
            }
            catch (CrudOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno en el servidor.");
            }
        }
    }
}
