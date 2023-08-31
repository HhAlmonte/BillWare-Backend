using BillWare.Application.Billing.Entities;
using BillWare.Application.Dashboard.Models;
using BillWare.Application.Interfaces;
using BillWare.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BillWare.Infrastructure.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DbSet<BillingEntity> _dbSet;

        public DashboardRepository(IBillWareDbContext context)
        {
            _dbSet = context.GetDbSet<BillingEntity>();
        }

        public async Task<List<StatisticsResponse>> GetSalesLast12Month()
        {
            DateTime initialDate = DateTime.Today.AddMonths(-12);

            var salesPerDay = await _dbSet.Where(x => x.CreatedAt >= initialDate)
                    .GroupBy(x => new { x.CreatedAt.Year, x.CreatedAt.Month, x.CreatedAt.Day })
                    .Select(group => new StatisticsResponse
                    {
                        SaleDate = $"{group.Key.Year}/{group.Key.Month:00}/{group.Key.Day:00}",
                        Amount = group.Sum(v => v.TotalPriceWithTax)
                    }).ToListAsync();

            return salesPerDay;
        }

        public async Task<List<StatisticsResponse>> GetSalesLast30Days()
        {
            DateTime initialDate = DateTime.Today.AddDays(-30);

            var salesPerDay = await _dbSet.Where(x => x.CreatedAt >= initialDate)
                    .GroupBy(x => x.CreatedAt.Date)
                    .Select(group => new StatisticsResponse
                    {
                        SaleDate = $"Día {group.Key.Day}",
                        Amount = group.Sum(v => v.TotalPriceWithTax)
                    }).ToListAsync();

            return salesPerDay;
        }
    }
}
