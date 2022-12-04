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
                    var separators = GetSeparators(numbers.Remove(indexOfFirstDigit - 1));
                    numbers = numbers.Remove(0, indexOfFirstDigit);

                    numbersToSum.AddRange(numbers.Split(separators.ToArray(), StringSplitOptions.None));
                }

                if (numbers.ElementAt(indexOfFirstDigit - 1) == '-' && numbers.ElementAt(indexOfFirstDigit - 2) == '\n')
                {
                    var separators = GetSeparators(numbers.Remove(indexOfFirstDigit - 2));
                    numbers = numbers.Remove(0, indexOfFirstDigit - 1);

                    numbersToSum.AddRange(numbers.Split(separators.ToArray(), StringSplitOptions.None));
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

        private static List<string> GetSeparators(string value)
        {
            var dictionary = new Dictionary<string, int>();
            var result = new List<string>();

            foreach (var ch in value)
            {
                if (!dictionary.TryAdd(ch.ToString(), 1))
                {
                    dictionary[ch.ToString()] += 1;
                }
            }

            foreach (var dict in dictionary)
            {
                result.Add(string.Concat(Enumerable.Repeat(dict.Key, dict.Value)));
            }

            return result;
        }
    }
}
