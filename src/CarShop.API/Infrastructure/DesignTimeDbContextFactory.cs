using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CarShop.API.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarShopDbContext>
    {
        public CarShopDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CarShopDbContext>();

            var connectionString = configuration.GetConnectionString(nameof(CarShop));

            builder.UseSqlServer(connectionString);

            return new CarShopDbContext(builder.Options);
        }
    }
}
