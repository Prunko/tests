using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal abstract class StationModule
    {
        private double _energyConsumption;
        
        public string Name { get; init; }
        public bool isRunning { get; set; }

        public StationModule(double energyConsumption, string name)
        {
            _energyConsumption = energyConsumption;
            Name = name;
        }

        public abstract void PerformDiagnostics();

        public virtual void Start()
        {
            isRunning = true;
        }
    }
}
