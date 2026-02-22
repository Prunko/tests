using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal interface IEnergySource
    {
        string EnergyType { get; set; }

        double GetOutput();
    }
}
