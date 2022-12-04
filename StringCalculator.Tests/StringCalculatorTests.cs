using Xunit;

namespace StringCalculator.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Should_Return_0_If_Empty_String_Passed()
        {
            //Arrange
            var emptyStringArgument = "";

            //Act
            var result = Calculator.Add(emptyStringArgument);

            //Assert
            Assert.Equal(0, result);
        }
    }
}
