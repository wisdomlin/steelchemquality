using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;
using NUnit.Framework;

namespace UseCase
{
    public class UC_SteelMillGasComposition
    {
        public double totalCOVolPercent;
        public double totalCO2VolPercent;
        public double totalCH4VolPercent;
        public double totalEqCO2FlowVol;
        public double totalEqCO2FlowMass;

        public bool Run()
        {
            bool result = true;

            var MillGasMgr = new MillGasMgr();

            MillGasMgr.Dic_GasSources.Add("Blast Furnace Gas", new GasSource
            {
                Name = "Blast Furnace Gas",
                PowerPlantUsage = 60,
                InternalUsage = 40,
                VolumetricFlow = 1780_000,
                CO = 25,
                CO2 = 23,
                N2 = 48,
                H2 = 4,
                CH4 = 0
            });
            MillGasMgr.Dic_GasSources.Add("Converter Gas", new GasSource
            {
                Name = "Converter Gas",
                PowerPlantUsage = 0,
                InternalUsage = 100,
                VolumetricFlow = 98_000,
                CO = 64,
                CO2 = 17,
                N2 = 14,
                H2 = 5,
                CH4 = 0
            });
            MillGasMgr.Dic_GasSources.Add("Coke Oven Gas", new GasSource
            {
                Name = "Coke Oven Gas",
                PowerPlantUsage = 43,
                InternalUsage = 57,
                VolumetricFlow = 152_000,
                CO = 7,
                CO2 = 2,
                N2 = 6,
                H2 = 63,
                CH4 = 22
            });

            totalCOVolPercent = MillGasMgr.GetTotalCOVolPercent();
            totalCO2VolPercent = MillGasMgr.GetTotalCO2VolPercent();
            totalCH4VolPercent = MillGasMgr.GetTotalCH4VolPercent();

            // Equivalent CO2 includes CO, CO2, and CH4.
            totalEqCO2FlowVol = MillGasMgr.GetTotalEqCO2FlowVol();
            totalEqCO2FlowMass = MillGasMgr.GetTotalEqCO2FlowMass();

            //double totalInternalUsage = MillGasMgr.GetTotalInternalUsagePercent();
            //Assert.AreEqual(45, totalInternalUsage, 1);  // %

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}
