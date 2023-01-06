using NUnit.Framework;
using System;
using UseCase;

namespace UseCase.Test
{
    class Test_UC_WaterManagementMultiSource
    {
        [Test]
        public void Test_UC_01_2022year()
        {
            // Arrange
            // Calculate the reclaimed water consumption for January 1, 2022
            DateTime AssessDate = new DateTime(2022, 1, 1);
            UC_WaterManagementMultiSource UC = new UC_WaterManagementMultiSource(AssessDate);

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(61000, UC.ReclaimedWaterConsumption, 1000);
            Assert.AreEqual(0.50, UC.SecondSourceRatio, 0.01);
        }

        [Test]
        public void Test_UC_02_2025year()
        {
            // Arrange
            // Calculate the total water consumption of the plant for January 1, 2025
            DateTime AssessDate = new DateTime(2025, 1, 1);
            UC_WaterManagementMultiSource UC = new UC_WaterManagementMultiSource(AssessDate);

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(70700, UC.ReclaimedWaterConsumption, 1000);
            Assert.AreEqual(0.58, UC.SecondSourceRatio, 0.01);
        }
    }
}
