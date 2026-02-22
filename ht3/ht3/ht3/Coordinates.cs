using System;
using System.Collections.Generic;
using System.Text;

namespace ht3
{
    public struct Coordinates
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Coordinates(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double GetDistance(Coordinates other)
        {
            double d = Math.Sqrt(Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2) + Math.Pow(other.z - z, 2));
            return d;
        }
    }
}
