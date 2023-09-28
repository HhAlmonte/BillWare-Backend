using BillWare.Application.Common.Models;
using BillWare.Application.Contracts;
using BillWare.Application.Interfaces;
using BillWare.Infrastructure.Context;
using BillWare.Infrastructure.Repository;
using BillWare.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BillWare.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("MailSettings"));
            
            services.AddDbContext<BillWareDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BillWareDatabase")));

            services.AddScoped(typeof(IBaseCrudRepository<>), typeof(BaseCrudRepository<>));

            services.AddScoped<IBillWareDbContext, BillWareDbContext>();

            services.AddScoped<IDashboardRepository, DashboardRepository>();

            services.AddScoped<IBillingRepository, BillingRepository>();

            services.AddScoped<IInventoryRepository, InventoryRepository>();

            services.AddScoped<IEmailServices, EmailServices>();

            return services;
        }
    }
}
