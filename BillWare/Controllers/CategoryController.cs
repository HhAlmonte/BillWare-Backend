using BillWare.Application.Category.Command;
using BillWare.Application.Category.Models;
using BillWare.Application.Category.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetCategoriesPagedWithSearch")]
        [Authorize]
        public async Task<ActionResult<PaginationResult<CategoryResponse>>> GetCategoriesPagedWithSearch(string search, int pageIndex, int pageSize)
        {
            var categories = await _mediator.Send(new GetCategoriesPagedWithSearchQuery(pageIndex, pageSize, search));

            return Ok(categories);
        }

        [HttpGet("GetCategoriesPaged")]
        [Authorize]
        public async Task<ActionResult<PaginationResult<CategoryResponse>>> GetCategoriesPaged(int pageIndex, int pageSize)
        {
            var categories = await _mediator.Send(new GetCategoriesPagedQuery(pageIndex, pageSize));

            return Ok(categories);
        }

        [HttpPost("CreateCategory")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<CategoryResponse>> CreateCategory(CategoryRequest request)
        {
            try
            {
                var createdCategory = await _mediator.Send(new CreateCategoryCommand(request));

                return Ok(createdCategory);
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

        [HttpPut("UpdateCategory")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<CategoryResponse>> UpdateCategory(CategoryRequest request)
        {
            var updatedCategory = await _mediator.Send(new UpdateCategoryCommand(request));

            return Ok(updatedCategory);
        }

        [HttpDelete("DeleteCategory/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                await _mediator.Send(new DeleteCategoryCommand(id));

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
