using NUnit.Framework;

namespace steelchemquality
{
    class Test_UC_PlantCapacityAnalysis
    {
        [Test]
        public void Test_UC_01()
        {
            // Arrange
            UC_PlantCapacityAnalysis UC = new UC_PlantCapacityAnalysis();

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
