using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GasSource
    {
        public string Name { get; set; }
        // PV=nRT: P, V, T
        public double VolumetricFlow { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        // Composition (%), n
        public double CO { get; set; }
        public double CO2 { get; set; }
        public double N2 { get; set; }
        public double H2 { get; set; }
        public double CH4 { get; set; }
        // Usage
        public double PowerPlantUsage { get; set; }
        public double InternalUsage { get; set; }
    }
}
