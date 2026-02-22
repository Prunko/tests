using System;
using System.Collections.Generic;
using System.Text;

namespace ht3
{
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
            }
            else { Console.WriteLine("There's no space!"); }
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
