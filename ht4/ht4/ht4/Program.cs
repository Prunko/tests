using System;

namespace ht4
{
    class Program
    {
        static void Main(string[] args)
        {
            using StationLog log = new StationLog();
            NuclearReactor nuclearReactor = new NuclearReactor();

            Console.WriteLine($"nuclearReactor energy output: {nuclearReactor.GetOutput()}");
        }
    }
}