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

            if (char.IsDigit(numbers.ElementAt(0))
                || (numbers.ElementAt(0) == '-' && char.IsDigit(numbers.ElementAt(1))))
            {
                numbersToSum.AddRange(numbers.Split(',', '\n'));
            }
            else
            {
                var indexOfFirstDigit = numbers.IndexOf(numbers.FirstOrDefault(char.IsDigit));

                if (numbers.ElementAt(indexOfFirstDigit - 1) == '\n')
                {
                    var separator = numbers.Remove(indexOfFirstDigit - 1);
                    numbersToSum.AddRange(numbers.Remove(0, indexOfFirstDigit - 1).Split(separator));
                }

                if (numbers.ElementAt(indexOfFirstDigit - 1) == '-' && numbers.ElementAt(indexOfFirstDigit - 2) == '\n')
                {
                    var separator = numbers.Remove(indexOfFirstDigit - 2);
                    numbersToSum.AddRange(numbers.Remove(0, indexOfFirstDigit - 2).Split(separator));
                }
            }

            try
            {
                var allNumbers = numbersToSum.Select(int.Parse).Where(n => n < 1000).ToList();

                var negativeNumbers = allNumbers.Where(n => n < 0).ToList();

                if (negativeNumbers.Count() != 0)
                {
                    throw new ArgumentException($"Negatives not allowed {string.Join(", ", negativeNumbers)}");
                }

                return allNumbers.Sum();
            }
            catch (FormatException)
            {
                throw new ArgumentException();
            }
        }
    }
}
