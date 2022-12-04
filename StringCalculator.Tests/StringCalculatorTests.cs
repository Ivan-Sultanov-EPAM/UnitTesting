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

        [Fact]
        public void Should_Return_Number()
        {
            //Arrange
            var stringWithNumber = "1";

            //Act
            var result = Calculator.Add(stringWithNumber);

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_Return_Sum_Of_Two_Numbers_With_Comma_Delimiter()
        {
            //Arrange
            var stringWithTwoNumbers = "1,2";

            //Act
            var result = Calculator.Add(stringWithTwoNumbers);

            //Assert
            Assert.Equal(3, result);
        }
    }
}
