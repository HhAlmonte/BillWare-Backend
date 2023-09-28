using BillWare.Application.Exceptions;
using BillWare.Application.Features.Billing.Entities;
using BillWare.Application.Features.Dashboard.Models;
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

            var salesPerMonth = await _dbSet
                .Where(x => x.CreatedAt >= initialDate)
                .GroupBy(x => new { x.CreatedAt.Year, x.CreatedAt.Month })
                .Select(group => new StatisticsResponse
                {
                    SaleDate = $"{group.Key.Year}/{group.Key.Month:00}/01",
                    Amount = group.Sum(v => v.TotalPriceWithTax)
                }).ToListAsync();

            if(salesPerMonth == null)
                throw new ValidationException("No se encontraron ventas");

            return salesPerMonth;
        }

        public async Task<List<StatisticsResponse>> GetSalesLast30Days()
        {
            DateTime initialDate = DateTime.Today.AddDays(-30);

            var salesPerDay = await _dbSet.Where(x => x.CreatedAt >= initialDate)
                    .GroupBy(x => x.CreatedAt.Date)
                    .Select(group => new StatisticsResponse
                    {
                        SaleDate = group.Key.ToString("dd/MM/yyyy"),
                        Amount = group.Sum(v => v.TotalPriceWithTax)
                    }).ToListAsync();

            if(salesPerDay == null)
                throw new ValidationException("No se encontraron ventas");

            return salesPerDay;
        }
    }
}
