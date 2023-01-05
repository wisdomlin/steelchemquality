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

    public class SteelMillGasMgr
    {
        public List<GasStream> GasStreams { get; set; }

        public SteelMillGasMgr()
        {
            GasStreams = new List<GasStream>();
            GasStreams.Add(new GasStream
            {
                Name = "Blast Furnace Gas",
                VolumetricFlow = 1780_000,
                CO = 25,
                CO2 = 23,
                N2 = 48,
                H2 = 4,
                CH4 = 0,
                PowerPlantUsage = 60,
                InternalUsage = 40
            });

            GasStreams.Add(new GasStream
            {
                Name = "Converter Gas",
                VolumetricFlow = 98_000,
                CO = 64,
                CO2 = 17,
                N2 = 14,
                H2 = 5,
                CH4 = 0,
                PowerPlantUsage = 0,
                InternalUsage = 100
            });

            GasStreams.Add(new GasStream
            {
                Name = "Coke Oven Gas",
                VolumetricFlow = 152_000,
                CO = 7,
                CO2 = 2,
                N2 = 6,
                H2 = 63,
                CH4 = 22,
                PowerPlantUsage = 43,
                InternalUsage = 57
            });

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

        public double GetTotalFlowVol_PowerPlantUsage()
        {
            double totalFlowVol = 0;
            foreach (var gasStream in GasStreams)
            {
                totalFlowVol += gasStream.VolumetricFlow * (gasStream.PowerPlantUsage / 100);
            }
            //int totalInternalUsagePercent = (int)(totalInternalUsage / totalFlowVol * 100);
            return totalFlowVol;
        }
    }
}
