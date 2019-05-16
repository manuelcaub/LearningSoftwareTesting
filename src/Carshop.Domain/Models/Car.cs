using System;

namespace CarShop.API.Domain.Models
{
    public class Car
    {
        public Car(string type, string name,
            int doors, int seats, int year, string fuel)
        {
            if (doors <= 0) throw new ArgumentOutOfRangeException(nameof(doors));
            if (seats <= 0) throw new ArgumentOutOfRangeException(nameof(seats));
            if (year <= 1900) throw new ArgumentOutOfRangeException(nameof(year));

            Type = type ?? throw new ArgumentNullException(nameof(type));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Doors = doors;
            Seats = seats;
            Year = year;
            Fuel = fuel ?? throw new ArgumentNullException(nameof(fuel));
            Id = Guid.NewGuid();
            ComputePrice();
        }

        public Guid Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get; private set; }

        public double Price { get; private set; }

        public int Doors { get; private set; }

        public int Seats { get; private set; }

        public int Year { get; private set; }

        public string Fuel { get; private set; }

        private void ComputePrice()
        {
            Price = Doors * 1000 + (Year * 10) + Seats * 3;
        }
    }
}
