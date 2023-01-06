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
        }
    }
}
