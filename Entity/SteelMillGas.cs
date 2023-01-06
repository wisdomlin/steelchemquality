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
        public double PowerPlantUsage { get; set; }
        public double InternalUsage { get; set; }
    }

    public class SteelMillGas
    {
        public List<GasStream> GasStreams { get; set; }

        public SteelMillGas()
        {
            GasStreams = new List<GasStream>();
        }

        public double GetTotalEqCO2FlowVol()
        {
            double totalEqCO2FlowVol = 0;
            foreach (var gasStream in GasStreams)
            {
                totalEqCO2FlowVol += gasStream.VolumetricFlow * (gasStream.CO / 100);
                totalEqCO2FlowVol += gasStream.VolumetricFlow * (gasStream.CO2 / 100);
                totalEqCO2FlowVol += gasStream.VolumetricFlow * (gasStream.CH4 / 100);
            }
            return totalEqCO2FlowVol;
        }

        public double GetTotalCO2VolPercent()
        {
            double totalFlowVol = 0;
            double totalFlowGasVol = 0;
            foreach (var gasStream in GasStreams)
            {
                totalFlowVol += gasStream.VolumetricFlow;
                totalFlowGasVol += gasStream.VolumetricFlow * (gasStream.CO2 / 100);
            }
            double totalFlowGasVolPercent = totalFlowGasVol / totalFlowVol * 100;
            return totalFlowGasVolPercent;
        }

        public double GetTotalCOVolPercent()
        {
            double totalFlowVol = 0;
            double totalFlowGasVol = 0;
            foreach (var gasStream in GasStreams)
            {
                totalFlowVol += gasStream.VolumetricFlow;
                totalFlowGasVol += gasStream.VolumetricFlow * (gasStream.CO / 100);
            }
            double totalFlowGasVolPercent = totalFlowGasVol / totalFlowVol * 100;
            return totalFlowGasVolPercent;
        }

        public double GetTotalEqCO2FlowMass()
        {
            throw new NotImplementedException();
        }

        public double GetTotalCH4VolPercent()
        {
            double totalFlowVol = 0;
            double totalFlowGasVol = 0;
            foreach (var gasStream in GasStreams)
            {
                totalFlowVol += gasStream.VolumetricFlow;
                totalFlowGasVol += gasStream.VolumetricFlow * (gasStream.CH4 / 100);
            }
            double totalFlowGasVolPercent = totalFlowGasVol / totalFlowVol * 100;
            return totalFlowGasVolPercent;
        }

        public double GetTotalInternalUsagePercent()
        {
            double totalFlowVol = 0;
            double totalInternalUsage = 0;
            foreach (var gasStream in GasStreams)
            {
                totalFlowVol += gasStream.VolumetricFlow;
                totalInternalUsage += gasStream.VolumetricFlow * (gasStream.InternalUsage / 100);
            }
            int totalInternalUsagePercent = (int)(totalInternalUsage / totalFlowVol * 100);
            return totalInternalUsagePercent;
        }
    }
}
