using BillWare.Application.Features.Dashboard.Models;
using BillWare.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BillWare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        [HttpGet("GetSalesLast30Days")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<StatisticsResponse>> GetSalesLast30Days()
        {
            if (!User.IsInRole("Administrator"))
            {
                return Unauthorized("Este usuario no esté autorizado para acción");
            }

            try
            {
                var content = await _dashboardRepository.GetSalesLast30Days();

                return Ok(content);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetSalesLast12Month")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(DataTable), 200)]
        public async Task<ActionResult<StatisticsResponse>> GetSalesLast12Month()
        {
            if (!User.IsInRole("Administrator"))
            {
                return Unauthorized("Este usuario no esté autorizado para acción");
            }

            try
            {
                var content = await _dashboardRepository.GetSalesLast12Month();

                return Ok(content);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
