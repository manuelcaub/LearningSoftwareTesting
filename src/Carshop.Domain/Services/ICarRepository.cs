using System;
using System.Threading.Tasks;
using CarShop.API.Domain.Models;

namespace CarShop.API.Domain.Services
{
    public interface ICarRepository
    {
        void Add(Car car);

        Task CommitAsync();

        Task DeleteAsync(Guid id);
    }
}
