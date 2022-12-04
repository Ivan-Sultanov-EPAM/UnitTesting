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

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2,3,4", 10)]
        [InlineData("1,2,3,4,5", 15)]
        [InlineData("0,2,3,4,100,500", 609)]
        public void Should_Return_Sum_Of_Unknown_Amount_Of_Numbers_With_Comma_Delimiter(string input, int expected)
        {
            //Arrange
            var inputString = input;

            //Act
            var result = Calculator.Add(inputString);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1,2\n3\n4", 10)]
        public void Should_Allow_NewLine_As_Delimiter(string input, int expected)
        {
            //Arrange
            var inputString = input;

            //Act
            var result = Calculator.Add(inputString);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
