using System;
using System.Collections.Generic;
using System.Text;

namespace ht3
{
    public struct Coordinates
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Coordinates(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double GetDistance(Coordinates other)
        {
            double d = Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2) + Math.Pow(other.z - z, 2));
            return d;
        }
    }

    public record CargoManifest(string Name, double Weight, string Category);

    public class SpaceShip
    {
        private double _fuel;
        private List<CargoManifest> _cargoManifests;
        public string Name { get; init; }
        public Coordinates CurrentPosition { get; set; }
        public double MaxCapacity { get; set; }
        public double currentWeight { get; set; }

        public SpaceShip(string name, double maxCapacity)
        {
            Name = name;
            MaxCapacity = maxCapacity;
        }

        public SpaceShip(double fuel, List<CargoManifest> cargoManifests, string name, Coordinates currentPosition, 
            double maxCapacity) : this(name, maxCapacity)
        {
            _fuel = fuel;
            _cargoManifests = cargoManifests ?? new List<CargoManifest>();
            CurrentPosition = currentPosition;
        }

        public void AddCargo(CargoManifest item)
        {
            if ((currentWeight += item.Weight) <= MaxCapacity)
            {
                _cargoManifests.Add(item);
                currentWeight += item.Weight;
            } else { Console.WriteLine("There's no space!"); }
        }

        public void PrintCargoNames()
        {
            foreach (var cargo in _cargoManifests)
            {
                Console.Write("\n\t-" + cargo.Name + "; "); 
            }
        }

        public void FlyTo(Coordinates newPosition)
        {
            double distance = CurrentPosition.GetDistance(newPosition);
            double fuelUsed = distance / 10;
            CurrentPosition = newPosition;
            _fuel -= fuelUsed; 
        }

        public void PrintCurrentPosition()
        {
            Console.Write("x = " + CurrentPosition.x +
                "; y = " + CurrentPosition.y +
                ": z = " + CurrentPosition.z);
        }
    }
}
