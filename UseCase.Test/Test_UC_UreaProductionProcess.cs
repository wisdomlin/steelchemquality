using NUnit.Framework;
using UseCase;

namespace UseCase.Test
{
    class Test_UC_UreaProductionProcess
    {
        [Test]
        public void Test_UC_01()
        {
            // Arrange
            UC_TraditionalBaseCase UC = new UC_TraditionalBaseCase();

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
