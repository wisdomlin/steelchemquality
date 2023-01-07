using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GasStream
    {
        public string Name { get; set; }
        public double VolumetricFlow { get; set; }
        public double CO { get; set; }
        public double CO2 { get; set; }
        public double N2 { get; set; }
        public double H2 { get; set; }
        public double CH4 { get; set; }
    }
}
