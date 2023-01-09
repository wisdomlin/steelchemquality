using NUnit.Framework;
using UseCase;

namespace UseCase.Test
{
    class Test_UC_SteelMillGasComposition
    {
        [Test]
        public void Test_MillGasMgrConstrAndGetFunction()
        {
            // Arrange
            UC_SteelMillGasComposition UC = new UC_SteelMillGasComposition();

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(26, UC.totalCOVolPercent, 1);  // %
            Assert.AreEqual(21, UC.totalCO2VolPercent, 1);  // %
            Assert.AreEqual(2, UC.totalCH4VolPercent, 1);  // %
            // Equivalent CO2 includes CO, CO2, and CH4.
            Assert.AreEqual(994700, UC.totalEqCO2FlowVol, 15000);  //  Nm^(3)h^(−1)
            Assert.AreEqual(1950, UC.totalEqCO2FlowMass, 150);  //  tonh^(−1) 
        }
    }
}
