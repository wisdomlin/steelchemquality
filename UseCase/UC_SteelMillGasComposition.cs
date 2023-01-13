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

            MillGasMgr gasMgr = new MillGasMgr();

            totalCOVolPercent = gasMgr.GetTotalCOVolPercent();
            totalCO2VolPercent = gasMgr.GetTotalCO2VolPercent();
            totalCH4VolPercent = gasMgr.GetTotalCH4VolPercent();

            // Equivalent CO2 includes CO, CO2, and CH4.
            totalEqCO2FlowVol = gasMgr.GetTotalEqCO2FlowVol();
            totalEqCO2FlowMass = gasMgr.GetTotalEqCO2FlowMass();

            //double totalInternalUsage = MillGasMgr.GetTotalInternalUsagePercent();
            //Assert.AreEqual(45, totalInternalUsage, 1);  // %

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}
