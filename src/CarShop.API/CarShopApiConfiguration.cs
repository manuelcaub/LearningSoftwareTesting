using System;
using CarShop.API.Domain.Services;
using CarShop.API.Infrastructure;
using CarShop.API.Infrastructure.Services;
using CarShop.Domain.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.API
{
    public class CarShopApiConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(nameof(CarShop));
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<CarShopDbContext>(context => { context.UseSqlServer(connectionString); });
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(typeof(CarShopApiConfiguration).Assembly));
            return services;
        }

        public static void Configure(IApplicationBuilder app, Func<IApplicationBuilder, IApplicationBuilder> configureHost)
        {
            configureHost(app)
                .UseMvc();
        }
    }
}