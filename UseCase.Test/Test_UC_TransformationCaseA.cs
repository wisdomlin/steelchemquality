using NUnit.Framework;
using UseCase;

namespace UseCase.Test
{
    class Test_UC_TransformationCaseA
    {
        [Test]
        public void Test_UC_01_gasMgr_DistributeSourceGas()
        {
            // Arrange
            UC_TransformationCaseA UC = new UC_TransformationCaseA();

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
            UC.gasMgr.Dic_GasStreams.TryGetValue("Gas-001", out var gasStream);
            // check volumetricflow
            Assert.AreEqual(1068000, gasStream.VolumetricFlow, "Gas-001 has wrong volumetric flow");
            // check chemical composition
            Assert.AreEqual(25, gasStream.CO, "Gas-001 has wrong CO composition");
            Assert.AreEqual(23, gasStream.CO2, "Gas-001 has wrong CO2 composition");
            Assert.AreEqual(48, gasStream.N2, "Gas-001 has wrong N2 composition");
            Assert.AreEqual(4, gasStream.H2, "Gas-001 has wrong H2 composition");
            Assert.AreEqual(0, gasStream.CH4, "Gas-001 has wrong CH4 composition");
        }
    }
}
