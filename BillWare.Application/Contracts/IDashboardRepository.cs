using BillWare.Application.Features.Dashboard.Models;

namespace BillWare.Application.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<StatisticsResponse>> GetSalesLast30Days();
        Task<List<StatisticsResponse>> GetSalesLast12Month();
    }
}
