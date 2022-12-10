using System;
using Xunit;

namespace MineFields.Tests
{
    public class MineFieldTests
    {
        [Fact]
        public void Should_Throw_ArgumentException_For_Invalid_Input()
        {
            //Arrange
            var inputField = "Invalid input";

            //Act
            Action action = () => MineFields.Process(inputField);

            //Assert
            var exception = Assert.Throws<ArgumentException>(action);
            Assert.Equal("Input value doesn't match required pattern", exception.Message);
        }

        [Theory]
        [InlineData("*...\n" +
                    "..*.\n" +
                    "....",
            "*211\n" +
            "12*1\n" +
            "0111")]
        [InlineData("....\n" +
                    "****\n" +
                    "....",
            "2332\n" +
            "****\n" +
            "2332")]
        [InlineData("*..*\n" +
                    "*..*\n" +
                    "*..*",
            "*22*\n" +
            "*33*\n" +
            "*22*")]
        [InlineData("*.*.\n" +
                    "....\n" +
                    ".**.",
            "*2*1\n" +
            "2432\n" +
            "1**1")]
        [InlineData("****\n" +
                    "****\n" +
                    "****",
            "****\n" +
            "****\n" +
            "****")]
        [InlineData("....\n" +
                    "....\n" +
                    "....",
            "0000\n" +
            "0000\n" +
            "0000")]
        public void Should_Produce_Correct_Output(string input, string expected)
        {
            //Arrange
            var inputString = input;

            //Act
            var result = MineFields.Process(inputString);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
