using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class MillGasMgr
    {
        public Dictionary<string, GasSource> Dic_GasSources { get; set; }
        //public Dictionary<string, GasStream> GasStreams { get; set; }

        public MillGasMgr()
        {
            //GasStreams = new Dictionary<string, GasStream>();
            Dic_GasSources = new Dictionary<string, GasSource>();
        }

        public double GetTotalEqCO2FlowVol()
        {
            double totalEqCO2FlowVol = 0;
            foreach (var gasSource in Dic_GasSources)
            {
                totalEqCO2FlowVol += gasSource.Value.VolumetricFlow * (gasSource.Value.CO / 100);
                totalEqCO2FlowVol += gasSource.Value.VolumetricFlow * (gasSource.Value.CO2 / 100);
                totalEqCO2FlowVol += gasSource.Value.VolumetricFlow * (gasSource.Value.CH4 / 100);
            }
            return totalEqCO2FlowVol;
        }
        public double GetTotalCO2VolPercent()
        {
            double totalFlowVol = 0;
            double totalFlowGasVol = 0;
            foreach (var (gasName, gasSource) in Dic_GasSources)
            {
                totalFlowVol += gasSource.VolumetricFlow;
                totalFlowGasVol += gasSource.VolumetricFlow * (gasSource.CO2 / 100);
            }
            double totalFlowGasVolPercent = totalFlowGasVol / totalFlowVol * 100;
            return totalFlowGasVolPercent;
        }
        public double GetTotalCOVolPercent()
        {
            double totalFlowVol = 0;
            double totalFlowGasVol = 0;
            foreach (var (gasName, gasSource) in Dic_GasSources)
            {
                totalFlowVol += gasSource.VolumetricFlow;
                totalFlowGasVol += gasSource.VolumetricFlow * (gasSource.CO / 100);
            }
            double totalFlowGasVolPercent = totalFlowGasVol / totalFlowVol * 100;
            return totalFlowGasVolPercent;
        }
        public double GetTotalEqCO2FlowMass()
        {
            return GetTotalEqCO2FlowVol() * 0.00196;    // Assume CO2: 1 cubic meter means 0.00196 tons
        }

        public double GetTotalCH4VolPercent()
        {
            double totalFlowVol = 0;
            double totalFlowGasVol = 0;
            foreach (var (gasName, gasSource) in Dic_GasSources)
            {
                totalFlowVol += gasSource.VolumetricFlow;
                totalFlowGasVol += gasSource.VolumetricFlow * (gasSource.CH4 / 100);
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
