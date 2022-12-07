using System.Collections.Generic;
using System.Text;

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

        public static string Convert(int number)
        {
            var digits = new List<int>();
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            var sb3 = new StringBuilder();
            var isNegative = number < 0;

            if (isNegative)
            {
                number *= -1;
                sb1.Append("  ");
                sb2.Append("_ ");
                sb3.Append("  ");
            }

            do
            {
                var temp = number % 10;
                digits.Add(number % 10);
                number = (number - temp) / 10;
            } while (number > 0);

            digits.Reverse();

            foreach (var digit in digits)
            {
                var numParts = Digits[digit].Split('\n');
                sb1.Append(numParts[0]);
                sb2.Append(numParts[1]);
                sb3.Append(numParts[2]);
            }

            return sb1.Append("\n").Append(sb2).Append("\n").Append(sb3).ToString();
        }
    }
}
