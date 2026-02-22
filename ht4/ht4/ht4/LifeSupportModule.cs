using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal class LifeSupportModule : StationModule
    {
        public double OxygenStatus;

        public LifeSupportModule(double oxygenStatus, double energyConsumption, string name) 
            : base(energyConsumption, name)
        {
            OxygenStatus = oxygenStatus;
        }

        public override void PerformDiagnostics()
        {
            Console.WriteLine("Oxygen status: " + OxygenStatus);
        }
    }
}
