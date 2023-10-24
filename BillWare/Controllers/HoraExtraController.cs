using BillWare.Application.Contracts.Repositories;
using BillWare.Application.HoraExtra.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoraExtraController : ControllerBase
    {
        private readonly IHoraExtraRepository _horaExtraRepository;

        public HoraExtraController(IHoraExtraRepository horaExtraRepository)
        {
            _horaExtraRepository = horaExtraRepository;
        }

        [HttpGet("GetHorasExtras")]
        public async Task<IActionResult> GetHorasExtras()
        {
            var result = await _horaExtraRepository.GetHorasExtras();

            return Ok(result);
        }

        [HttpPost("CrearSolicitud")]
        public async Task<IActionResult> CrearSolicitud([FromBody] HoraExtraEntity solicitudRequest)
        {
            var result = await _horaExtraRepository.CreateSolicitudHoraExtra(solicitudRequest);

            return Ok(result);
        }

        [HttpPost("ActualizarSolicitud")]
        public async Task<IActionResult> ActualizarSolicitud([FromBody] HoraExtraEntity solicitudRequest)
        {
            var result = await _horaExtraRepository.UpdateSolicitudHoraExtra(solicitudRequest);

            return Ok(result);
        }

        [HttpPost("DenegarSolicitud")]
        public async Task<IActionResult> DenegarSolicitud([FromBody] int idSolicitud)
        {
            var result = await _horaExtraRepository.DenegarSolicitud(idSolicitud);

            return Ok(result);
        }

        [HttpPost("ActualizarEstatusSolicitud")]
        public async Task<IActionResult> ActualizarEstatusSolicitud([FromBody] int idSolicitud, int estatusId)
        {
            var result = await _horaExtraRepository.UpdateStatusHoraExtra(idSolicitud, estatusId);

            return Ok(result);
        }
    }
}
