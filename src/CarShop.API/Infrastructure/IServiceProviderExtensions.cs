using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarShop.API.Infrastructure
{
    public static class IServiceProviderExtensions
    {
        public static IServiceProvider MigrateDbContext<TContext>(this IServiceProvider services)
            where TContext : DbContext
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TContext>();
                context.Database.Migrate();
            }

            return services;
        }

        public async static Task<IServiceProvider> MigrateDbContextAsync<TContext>(this IServiceProvider services)
            where TContext : DbContext
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TContext>();
                await context.Database.MigrateAsync();
            }

            return services;
        }
    }
}
