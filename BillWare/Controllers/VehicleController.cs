using BillWare.Application.Vehicle.Command;
using BillWare.Application.VehiculoEntrance.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpDelete("DeleteVehicle/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteVehicleCommand(id));

            return Ok(result);
        }

        [HttpPost("CreateVehicle")]
        public async Task<IActionResult> Post([FromBody] VehicleModel vehicleModel)
        {
            var result = await _mediator.Send(new CreateVehicleCommand(vehicleModel));

            return Ok(result);
        }

        [HttpPut("UpdateVehicle")]
        public async Task<IActionResult> Put([FromBody] VehicleModel vehicleModel)
        {
            var result = await _mediator.Send(new UpdateVehicleCommand(vehicleModel));

            return Ok(result);
        }
    }
}
