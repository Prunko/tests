using System;

namespace ht3
{
    class Program
    {
        static void Main(string[] args)
        {
            CargoManifest cargo1 = new CargoManifest("Rifles", 150.0, "Weapons");
            CargoManifest cargo2 = new CargoManifest("Medkits", 50.0, "Pharmacy");
            CargoManifest cargo3 = cargo1 with { Name = "Machineguns" };

            SpaceShip spaceShip1 = new SpaceShip(
                240.0, 
                null, 
                "Aurora", 
                new Coordinates { x = 122.3, y = -343.7, z = 109.0 }, 
                1200.0);

            spaceShip1.AddCargo(cargo1);
            spaceShip1.AddCargo(cargo2);
            spaceShip1.AddCargo(cargo3);

            spaceShip1.FlyTo(new Coordinates { x = 144.9, y = 1236.2, z = -256.5 });

            Console.Write("===REPORT===");
            Console.Write("\nSpaceShip: " + spaceShip1.Name);
            Console.Write("\nCurrent coordinates: ");
            spaceShip1.PrintCurrentPosition();
            Console.Write("\nCargo:");
            spaceShip1.PrintCargoNames();
        }
    }
}