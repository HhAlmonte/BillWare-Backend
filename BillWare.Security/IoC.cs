using BillWare.Application.Contracts.Persistence;
using BillWare.Application.Contracts.Service;
using BillWare.Application.Features.Account.Models;
using BillWare.Identity.Services;
using BillWare.Infrastructure.Security.Repository;
using BillWare.Infrastructure.Security.Services;
using BillWare.Security.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BillWare.Infrastructure.Security
{
    public static class IoC
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSetting"));

            services.AddDbContext<SecurityDbContext>(op =>
                op.UseSqlServer(configuration.GetConnectionString("BillWareSecurityConnectionString"),
                b => b.MigrationsAssembly(typeof(SecurityDbContext).Assembly.FullName)));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SecurityDbContext>();

            /*services.AddIdentity<UserIdentity, IdentityRole>()
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();*/

            services.AddTransient<IAuthService, AuthService>();

            services.AddScoped<ITokenService, TokenService>();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSetting:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = false,
                ClockSkew = TimeSpan.Zero,
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;
                op.SaveToken = true;
                op.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
