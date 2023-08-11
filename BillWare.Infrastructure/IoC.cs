using BillWare.Application.Interfaces;
using BillWare.Application.Repositories;
using BillWare.Application.Shared;
using BillWare.Application.User.Entities;
using BillWare.Infrastructure.Context;
using BillWare.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BillWare.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            /*var _builder = services.AddIdentityCore<UserEntity>();

            _builder = new IdentityBuilder(_builder.UserType, _builder.Services);
            _builder.AddRoles<IdentityRole>();
            _builder.AddEntityFrameworkStores<BillWareSecurityDbContext>();
            _builder.AddSignInManager<SignInManager<UserEntity>>();

            services.TryAddSingleton<ISystemClock, SystemClock>();*/

            services.AddDbContext<BillWareDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BillWareDatabase")));
/*
            services.AddDbContext<BillWareSecurityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BillWareSecurityDatabase")));*/

            services.AddScoped(typeof(IBaseCrudRepository<>), typeof(BaseCrudRepository<>));

            services.AddScoped<IVehicleEntranceRepository, VehicleEntranceRepository>();

            services.AddScoped<IBillWareDbContext, BillWareDbContext>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();

            services.AddScoped<IBillingRepository, BillingRepository>();

            services.AddScoped<IInventoryRepository, InventoryRepository>();

            return services;
        }
    }
}
