﻿using System.Linq;

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

            var numbersToSum = numbers.Split(',');

            return numbersToSum.Sum(int.Parse);
        }
    }
}
