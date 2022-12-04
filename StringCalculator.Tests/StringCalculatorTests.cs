using System;
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

        [Theory]
        [InlineData("1,")]
        [InlineData("1,\n")]
        public void Should_Throw_ArgumentException_For_Extra_Delimiters(string input)
        {
            //Arrange
            var inputString = input;

            //Act
            Action action = () => Calculator.Add(inputString);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Theory]
        [InlineData(";\n1;2", 3)]
        [InlineData("#\n1#2#3", 6)]
        [InlineData("@\n1@2@3@4", 10)]
        public void Should_Read_First_Line_As_A_Custom_Delimiter(string input, int expected)
        {
            //Arrange
            var inputString = input;

            //Act
            var result = Calculator.Add(inputString);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-1", "Negatives not allowed -1")]
        [InlineData("1\n-2", "Negatives not allowed -2")]
        [InlineData("@\n-1@-2@-3@4", "Negatives not allowed -1, -2, -3")]
        public void Should_Throw_ArgumentException_For_Negative_numbers(string input, string message)
        {
            //Arrange
            var inputString = input;

            //Act
            Action action = () => Calculator.Add(inputString);

            //Assert
            var exception = Assert.Throws<ArgumentException>(action);
            Assert.Equal(message, exception.Message);
        }

        [Theory]
        [InlineData("1001", 0)]
        [InlineData(";\n1;1001", 1)]
        [InlineData("#\n1#2#1100", 3)]
        public void Should_Ignore_Numbers_Bigger_Than_1000(string input, int expected)
        {
            //Arrange
            var inputString = input;

            //Act
            var result = Calculator.Add(inputString);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(";;;\n1;;;2", 3)]
        [InlineData("####\n1####2####3", 6)]
        [InlineData("@@\n1@@2@@3@@4", 10)]
        public void Should_Allow_Custom_Delimiter_Of_Any_Length(string input, int expected)
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
