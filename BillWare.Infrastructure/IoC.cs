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

            services.AddScoped<IBillWareDbContext, BillWareDbContext>();

            return services;
        }
    }
}
