using BillWare.Application.Costumer.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CostumerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetCostumerById")]
        public async Task<IActionResult> GetCostumerById(int id)
        {
            var costumer = await mediator.Send(new GetCostumerByIdQuery(id));

            return Ok(costumer);
        }
    }
}
