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
        public Dictionary<string, GasStream> Dic_GasStreams { get; set; }

        public MillGasMgr()
        {
            Dic_GasStreams = new Dictionary<string, GasStream>();

            Dic_GasSources = new Dictionary<string, GasSource>();
            Dic_GasSources.Add("Blast Furnace Gas", new GasSource
            {
                Name = "Blast Furnace Gas",
                VolumetricFlow = 1780_000,
                CO = 25,
                CO2 = 23,
                N2 = 48,
                H2 = 4,
                CH4 = 0,
                DicUsage = new Dictionary<string, double>()
                {
                    { "Power Plant Usage", 60},
                    { "Internal Usage", 40 }
                }
            });
            Dic_GasSources.Add("Converter Gas", new GasSource
            {
                Name = "Converter Gas",
                VolumetricFlow = 98_000,
                CO = 64,
                CO2 = 17,
                N2 = 14,
                H2 = 5,
                CH4 = 0,
                DicUsage = new Dictionary<string, double>()
                {
                    { "Power Plant Usage", 0},
                    { "Internal Usage", 100 }
                }
            });
            Dic_GasSources.Add("Coke Oven Gas", new GasSource
            {
                Name = "Coke Oven Gas",
                VolumetricFlow = 152_000,
                CO = 7,
                CO2 = 2,
                N2 = 6,
                H2 = 63,
                CH4 = 22,
                DicUsage = new Dictionary<string, double>()
                {
                    { "Power Plant Usage", 43},
                    { "Internal Usage", 57 }
                }
            });
        }

        // Get Total XXX Vol Percnet
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
        // Get Total Equivalent
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
        public double GetTotalEqCO2FlowMass()
        {
            return GetTotalEqCO2FlowVol() * 0.00196;    // Assume CO2: 1 cubic meter means 0.00196 tons
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

        public void DistributeGasStreams()
        {
            int i = 1;
            foreach (var (gasName, gasSource) in Dic_GasSources)
            {
                foreach (var (usageName, UsageAmount) in gasSource.DicUsage)
                {
                    GasStream gasStream = new GasStream
                    {
                        Name = $"Gas-{i:D3}",
                        VolumetricFlow = gasSource.VolumetricFlow * UsageAmount / 100,
                        Temperature = 0,
                        Pressure = 101325,
                        CO = gasSource.CO,
                        CO2 = gasSource.CO2,
                        N2 = gasSource.N2,
                        H2 = gasSource.H2,
                        CH4 = gasSource.CH4
                    };
                    this.Dic_GasStreams.Add(gasStream.Name, gasStream);
                    i++;
                }
            }
        }
    }
}
