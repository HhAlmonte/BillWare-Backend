using BillWare.Application.Costumer.Command;
using BillWare.Application.Costumer.Models;
using BillWare.Application.Costumer.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleEntranceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleEntranceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetVehicleEntrancePaged")]
        public async Task<ActionResult<PaginationResult<VehiculoEntranceVM>>> Get(int pageIndex = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(new GetVehiclesEntrancePagedQuery(pageIndex, pageSize));

            return Ok(result);
        }

        [HttpGet("GetVehicleEntranceWithParams")]
        public async Task<ActionResult<PaginationResult<VehiculoEntranceVM>>> Get(int pageIndex, int pageSize, string fullName = null)
        {
            var result = await _mediator.Send(new GetVehiclesEntrancePagedWithParamsQuery(pageIndex, pageSize, fullName));

            return Ok(result);
        }

        [HttpPost("CreateVehicleEntrance")]
        public async Task<ActionResult<VehiculoEntranceVM>> Post([FromBody] VehiculoEntranceCommandModel costumer)
        {
            var result = await _mediator.Send(new CreateVehicleEntranceCommand(costumer));

            return Ok(result);
        }

        [HttpDelete("DeleteVehicleEntrance/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteVehicleEntranceCommand(id));

            return Ok();
        }

        [HttpPut("UpdateVehicleEntrance")]
        public async Task<ActionResult<VehiculoEntranceVM>> Put([FromBody] VehiculoEntranceCommandModel costumer)
        {
            var result = await _mediator.Send(new UpdateVehicleEntranceCommand(costumer));

            return Ok(result);
        }
    }
}
