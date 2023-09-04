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
        public async Task<IActionResult> GetSalesLast30Days()
        {
            var sales = await _dashboardRepository.GetSalesLast30Days();

            return Ok(sales);
        }

        [HttpGet("GetSalesLast12Month")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetSalesLast12Month()
        {
            var sales = await _dashboardRepository.GetSalesLast12Month();

            return Ok(sales);
        }
    }
}
