using BillWare.Application.Features.Category.Command;
using BillWare.Application.Features.Category.Models;
using BillWare.Application.Features.Category.Query;
using BillWare.Application.Features.Costumer.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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


        [Authorize]
        [HttpGet("GetListPagedWithSearch")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<CategoryResponse>>> GetCategoriesPagedWithSearch(string search, int pageIndex, int pageSize)
        {
            var query = new GetCategoriesPagedWithSearchQuery
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
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationResult<CategoryResponse>>> GetCategoriesPaged(int pageIndex, int pageSize)
        {
            var query = new GetCategoriesPagedQuery
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
        public async Task<ActionResult<CategoryResponse>> CreateCategory(CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("Update")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<CategoryResponse>> UpdateCategory(UpdateCategoryCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(CostumerResponse), (int)HttpStatusCode.OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand(id));

            return Ok(response);
        }
    }
}
