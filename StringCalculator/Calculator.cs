using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }

            var numbersToSum = numbers.Split(',', '\n');

            try
            {
                return numbersToSum.Sum(int.Parse);
            }
            catch (FormatException)
            {
                throw new ArgumentException();
            }
        }
    }
}
