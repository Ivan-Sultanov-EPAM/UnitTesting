using System.Collections.Generic;

namespace LCDDigits
{
    public class LCDConverter
    {
        private static readonly Dictionary<int, string> Digits = new Dictionary<int, string>()
        {
            { 0, " _ \n" +
                 "| |\n" +
                 "|_|" },
            { 1, "   \n" +
                 "  |\n" +
                 "  |" },
            { 2, " _ \n" +
                 " _|\n" +
                 "|_ " },
            { 3, " _ \n" +
                 " _|\n" +
                 " _|" },
            { 4, "   \n" +
                 "|_|\n" +
                 "  |" },
            { 5, " _ \n" +
                 "|_ \n" +
                 " _|" },
            { 6, " _ \n" +
                 "|_ \n" +
                 "|_|" },
            { 7, " _ \n" +
                 "  |\n" +
                 "  |" },
            { 8, " _ \n" +
                 "|_|\n" +
                 "|_|" },
            { 9, " _ \n" +
                 "|_|\n" +
                 "  |" }
        };

        public static string Convert(int digit)
        {
            return Digits[digit];
        }
    }
}
