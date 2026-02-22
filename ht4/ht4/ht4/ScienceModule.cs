using System;
using System.Collections.Generic;
using System.Text;

namespace ht4
{
    internal class ScienceModule : StationModule
    {
        List<string> ResearchProjects;

        public ScienceModule(List<string> researchProjects, double energyConsumption, string name)
            : base(energyConsumption, name)
        {
            ResearchProjects = researchProjects;
        }

        public override void PerformDiagnostics()
        {
        }

        public override void Start()
        {
            base.Start();
            Console.WriteLine("Getting ready the microscopes...");
        }
    }
}
