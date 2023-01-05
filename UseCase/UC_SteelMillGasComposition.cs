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
        public bool Run()
        {
            bool result = true;

            var MillGasMgr = new SteelMillGasMgr();

            double totalCO2VolPercent = MillGasMgr.GetTotalCO2VolPercent();
            double totalCOVolPercent = MillGasMgr.GetTotalCOVolPercent();
            double totalCH4VolPercent = MillGasMgr.GetTotalCH4VolPercent();
            Assert.AreEqual(21, totalCO2VolPercent, 1);
            Assert.AreEqual(26, totalCOVolPercent, 1);
            Assert.AreEqual(2, totalCH4VolPercent, 1);

            double totalEqCO2FlowVol = MillGasMgr.GetTotalEqCO2FlowVol();
            Assert.AreEqual(994700, totalEqCO2FlowVol, 15000);  //  Nm3h−1 

            double totalInternalUsage = MillGasMgr.GetTotalInternalUsagePercent();
            Assert.AreEqual(45, totalInternalUsage, 1);

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}
