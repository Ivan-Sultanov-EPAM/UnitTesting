using Xunit;

namespace LCDDigits.Tests
{
    public class LCDDigitsTests
    {
        [Theory]
        [InlineData(0, " _ \n" +
                       "| |\n" +
                       "|_|")]
        [InlineData(1, "   \n" +
                       "  |\n" +
                       "  |")]
        [InlineData(2, " _ \n" +
                       " _|\n" +
                       "|_ ")]
        [InlineData(3, " _ \n" +
                       " _|\n" +
                       " _|")]
        [InlineData(4, "   \n" +
                       "|_|\n" +
                       "  |")]
        [InlineData(5, " _ \n" +
                       "|_ \n" +
                       " _|")]
        [InlineData(6, " _ \n" +
                       "|_ \n" +
                       "|_|")]
        [InlineData(7, " _ \n" +
                       "  |\n" +
                       "  |")]
        [InlineData(8, " _ \n" +
                       "|_|\n" +
                       "|_|")]
        [InlineData(9, " _ \n" +
                       "|_|\n" +
                       "  |")]
        public void Should_Print_Digits_From_0_To_9(int input, string expected)
        {
            //Arrange
            var digit = input;

            //Act
            var result = LCDConverter.Convert(digit);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(125, "    _  _ \n" +
                         "  | _||_ \n" +
                         "  ||_  _|")]
        [InlineData(910, " _     _ \n" +
                         "|_|  || |\n" +
                         "  |  ||_|")]
        [InlineData(8888, " _  _  _  _ \n" +
                          "|_||_||_||_|\n" +
                          "|_||_||_||_|")]
        public void Should_Print_Any_Positive_Integer(int input, string expected)
        {
            //Arrange
            var digit = input;

            //Act
            var result = LCDConverter.Convert(digit);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
