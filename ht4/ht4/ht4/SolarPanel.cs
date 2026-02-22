using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal class SolarPanel : IEnergySource
    {
        public readonly double StandardEnergyOutput = 100;

        public double SolarIntensivity { get; set; }

        public string EnergyType { get; set; }

        public double GetOutput()
        {
            return SolarIntensivity * StandardEnergyOutput;
        }
    }
}
