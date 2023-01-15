using NUnit.Framework;
using UseCase;

namespace UseCase.Test
{
    class Test_UC_Iteration
    {
        [Test]
        public void Test_UC_01()
        {
            // Arrange
            UC_Iteration UC = new UC_Iteration();

            // Act
            bool result;
            result = UC.Run();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
