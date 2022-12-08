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
    }
}
