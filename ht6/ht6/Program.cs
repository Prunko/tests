using System;

namespace ht4
{
    class Program
    {
        static void Main(string[] args)
        {
            var newWarehouse = new Warehouse();

            newWarehouse.OnItemChanged += (index, name) => Console.WriteLine($"LOG: Item {name} was added in slot #{index}");

            var items = new List<string> { "Toothpaste", "Bullets", "Pacifiers" };

            Predicate<string> isEmpty = item => string.IsNullOrWhiteSpace( item );

            Func<string, string> result = name => name.ToUpper();

            foreach(string s in items)
            {
                if ( isEmpty( s ) )
                {
                    Console.WriteLine("There's no name of product!");
                    continue;
                }

                bool isAdded = false;

                for (int i = 0; i < 10; i++)
                {
                    if(newWarehouse[i] == null)
                    {
                        newWarehouse[i] = result(s);

                        isAdded = true;

                        break;
                    }
                }

                if(!isAdded)
                {
                    Console.WriteLine("Warehouse is full");
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (!string.IsNullOrWhiteSpace(newWarehouse[i]))
                {
                    Console.WriteLine($"{newWarehouse[i]}");
                }
            }
        }
    }
}