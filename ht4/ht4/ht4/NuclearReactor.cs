using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal class NuclearReactor : IEnergySource
    {
        public readonly double StandardEnergyOutput = 1500;
        public string EnergyType { get; set; }

        public double GetOutput()
        {
            return StandardEnergyOutput;
        }
    }
}
