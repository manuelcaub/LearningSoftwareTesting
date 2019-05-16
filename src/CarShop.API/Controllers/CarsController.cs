using System;
using System.Threading.Tasks;
using CarShop.API.Domain.Models;
using CarShop.API.Domain.Services;
using CarShop.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository ?? throw new ArgumentNullException(nameof(carRepository));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarDto carDto)
        {
            var car = new Car(carDto.Type, carDto.Name, carDto.Doors,
                carDto.Seats, carDto.Year, carDto.Fuel);

            _carRepository.Add(car);
            await _carRepository.CommitAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _carRepository.DeleteAsync(id);
            await _carRepository.CommitAsync();
            return Ok();
        }
    }
}
