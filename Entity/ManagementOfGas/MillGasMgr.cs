using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MillGasMgr
    {
        public List<GasDistribution> GasDistributions { get; set; }
        public List<GasStream> GasStreams { get; set; }

        public MillGasMgr()
        {
            GasStreams = new List<GasStream>();

            GasDistributions = new List<GasDistribution>();
            GasDistributions.Add(new GasDistribution
            {
                Name = "Blast Furnace Gas",
                PowerPlantUsage = 60,
                InternalUsage = 40
            });

            GasDistributions.Add(new GasDistribution
            {
                Name = "Converter Gas",
                PowerPlantUsage = 0,
                InternalUsage = 100
            });

            GasDistributions.Add(new GasDistribution
            {
                Name = "Coke Oven Gas",
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
        //public double GetTotalInternalUsagePercent()
        //{
        //    double totalFlowVol = 0;
        //    double totalInternalUsage = 0;
        //    foreach (var gasStream in GasStreams)
        //    {
        //        totalFlowVol += gasStream.VolumetricFlow;
        //        totalInternalUsage += gasStream.VolumetricFlow * (gasStream.InternalUsage / 100);
        //    }
        //    int totalInternalUsagePercent = (int)(totalInternalUsage / totalFlowVol * 100);
        //    return totalInternalUsagePercent;
        //}

        //public double GetTotalFlowVol_PowerPlantUsage()
        //{
        //    double totalFlowVol = 0;
        //    foreach (var gasStream in GasStreams)
        //    {
        //        totalFlowVol += gasStream.VolumetricFlow * (gasStream.PowerPlantUsage / 100);
        //    }
        //    return totalFlowVol;
        //}
    }
}
