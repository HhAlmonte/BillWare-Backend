using BillWare.Application.Interfaces;
using BillWare.Application.Repositories;
using BillWare.Application.Shared;
using BillWare.Infrastructure.Context;
using BillWare.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BillWare.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BillWareDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BillWareDatabase")));

            services.AddScoped(typeof(IBaseCrudRepository<>), typeof(BaseCrudRepository<>));

            services.AddScoped<IVehicleEntranceRepository, VehicleEntranceRepository>();

            services.AddScoped<IBillWareDbContext, BillWareDbContext>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();

            services.AddScoped<IBillingRepository, BillingRepository>();

            return services;
        }
    }
}
