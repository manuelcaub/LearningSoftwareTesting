using System.Threading.Tasks;
using CarShop.API.Domain.Models;
using CarShop.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CarShop.API.Infrastructure
{
    public class CarShopDbContext : DbContext
    {
        public CarShopDbContext(DbContextOptions<CarShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(build => { build.HasKey(e => e.Id); });
        }
    }
}
