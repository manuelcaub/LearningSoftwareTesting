using System;
using System.Threading.Tasks;
using CarShop.API.Domain.Models;
using CarShop.API.Domain.Services;

namespace CarShop.API.Infrastructure.Services
{
    public class CarRepository : ICarRepository
    {
        private readonly CarShopDbContext _context;

        public CarRepository(CarShopDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
        }
    }
}
