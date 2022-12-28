using NUnit.Framework;
using UseCase;

namespace UseCase.Test
{
    class Test_UC_SteelMillGasComposition
    {
        [Test]
        public void Test_UC_01()
        {
            // Arrange
            UC_SteelMillGasComposition UC = new UC_SteelMillGasComposition();

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
