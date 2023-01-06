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

            var steelMillGas = new SteelMillGas();

            steelMillGas.GasStreams.Add(new GasStream
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

            steelMillGas.GasStreams.Add(new GasStream
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

            steelMillGas.GasStreams.Add(new GasStream
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

            double totalCOVolPercent = steelMillGas.GetTotalCOVolPercent();
            Assert.AreEqual(26, totalCOVolPercent, 1);

            double totalCO2VolPercent = steelMillGas.GetTotalCO2VolPercent();
            Assert.AreEqual(21, totalCO2VolPercent, 1);

            double totalCH4VolPercent = steelMillGas.GetTotalCH4VolPercent();
            Assert.AreEqual(2, totalCH4VolPercent, 1);

            double totalEqCO2FlowVol = steelMillGas.GetTotalEqCO2FlowVol();
            Assert.AreEqual(994700, totalEqCO2FlowVol, 15000);  //  Nm^(3)h^(−1)

            double totalEqCO2FlowMass = steelMillGas.GetTotalEqCO2FlowMass();
            Assert.AreEqual(1950, totalEqCO2FlowMass, 150);  //  tonh^(−1) 

            double totalInternalUsage = steelMillGas.GetTotalInternalUsagePercent();
            Assert.AreEqual(45, totalInternalUsage, 1);
            //Console.WriteLine($"Total internal usage: {totalInternalUsage}%");

            //result &= this.PrepareOriginalTs();
            return result;
        }
    }
}
