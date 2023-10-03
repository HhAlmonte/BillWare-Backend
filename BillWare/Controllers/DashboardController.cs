using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Features.Dashboard.Models;
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
        [ProducesResponseType(typeof(StatisticsResponse), 200)]
        public async Task<ActionResult<StatisticsResponse>> GetSalesLast30Days()
        {
            var response = await _dashboardRepository.GetSalesLast30Days();

            return Ok(response);
        }

        [HttpGet("GetSalesLast12Month")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(StatisticsResponse), 200)]
        public async Task<ActionResult<StatisticsResponse>> GetSalesLast12Month()
        {
            var response = await _dashboardRepository.GetSalesLast12Month();

            return Ok(response);
        }
    }
}
