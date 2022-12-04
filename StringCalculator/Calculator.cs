using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            var numbersToSum = new List<string>();

            if (numbers == "")
            {
                return 0;
            }

            if (char.IsDigit(numbers.ElementAt(0)))
            {
                numbersToSum.AddRange(numbers.Split(',', '\n'));
            }

            if (!char.IsDigit(numbers.ElementAt(0)) && numbers.ElementAt(1) == '\n')
            {
                var separator = numbers.ElementAt(0);

                numbers = numbers.Remove(0, 2);

                numbersToSum.AddRange(numbers.Split(separator));
            }

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
