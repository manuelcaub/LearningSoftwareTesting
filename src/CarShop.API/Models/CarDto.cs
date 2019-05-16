using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace CarShop.API.Models
{
    public class CarDto
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public int Doors { get; set; }

        public int Seats { get; set; }

        public int Year { get; set; }

        public string Fuel { get; set; }

        public class Validator : AbstractValidator<CarDto>
        {
            public Validator()
            {
                RuleFor(x => x.Fuel).NotEmpty();
                RuleFor(x => x.Type).NotEmpty();
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.Year).GreaterThan(1900);
                RuleFor(x => x.Doors).GreaterThan(0);
                RuleFor(x => x.Seats).GreaterThanOrEqualTo(2).LessThanOrEqualTo(5);
            }
        }
    }
}
