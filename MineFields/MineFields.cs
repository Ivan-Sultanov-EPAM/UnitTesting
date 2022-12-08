using System;
using System.Text.RegularExpressions;

namespace MineFields
{
    public class MineFields
    {
        private const string Pattern = @"^[*.]{4}\n[*.]{4}\n[*.]{4}$";

        public static string Process(string inputField)
        {
            if (!Regex.IsMatch(inputField, Pattern))
            {
                throw new ArgumentException("Input value doesn't match required pattern");
            }

            throw new NotImplementedException();
        }
    }
}
