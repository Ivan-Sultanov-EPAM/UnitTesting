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

            var stringArray = new string[3][];
            stringArray[0] = new string[4];
            stringArray[1] = new string[4];
            stringArray[2] = new string[4];

            var fieldParts = inputField.Split("\n");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    stringArray[i][j] = fieldParts[i][j].ToString();
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (stringArray[i][j] == ".")
                    {
                        stringArray[i][j] = "0";
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (stringArray[i][j] == "*")
                    {
                        ProcessMine(i, j);
                    }
                }
            }

            void ProcessMine(int i, int j)
            {
                if (j + 1 < 4 && stringArray[i][j + 1] != "*")
                {
                    var temp = int.Parse(stringArray[i][j + 1]);
                    temp += 1;
                    stringArray[i][j + 1] = temp.ToString();
                }

                if (j - 1 > -1 && stringArray[i][j - 1] != "*")
                {
                    var temp = int.Parse(stringArray[i][j - 1]);
                    temp += 1;
                    stringArray[i][j - 1] = temp.ToString();
                }

                if (i + 1 < 3 && stringArray[i + 1][j] != "*")
                {
                    var temp = int.Parse(stringArray[i + 1][j]);
                    temp += 1;
                    stringArray[i + 1][j] = temp.ToString();
                }

                if (i - 1 > -1 && stringArray[i - 1][j] != "*")
                {
                    var temp = int.Parse(stringArray[i - 1][j]);
                    temp += 1;
                    stringArray[i - 1][j] = temp.ToString();
                }

                if (i + 1 < 3 && j + 1 < 4 && stringArray[i + 1][j + 1] != "*")
                {
                    var temp = int.Parse(stringArray[i + 1][j + 1]);
                    temp += 1;
                    stringArray[i + 1][j + 1] = temp.ToString();
                }

                if (i - 1 > -1 && j - 1 > -1 && stringArray[i - 1][j - 1] != "*")
                {
                    var temp = int.Parse(stringArray[i - 1][j - 1]);
                    temp += 1;
                    stringArray[i - 1][j - 1] = temp.ToString();
                }

                if (i + 1 < 3 && j - 1 > -1 && stringArray[i + 1][j - 1] != "*")
                {
                    var temp = int.Parse(stringArray[i + 1][j - 1]);
                    temp += 1;
                    stringArray[i + 1][j - 1] = temp.ToString();
                }

                if (i - 1 > -1 && j + 1 < 4 && stringArray[i - 1][j + 1] != "*")
                {
                    var temp = int.Parse(stringArray[i - 1][j + 1]);
                    temp += 1;
                    stringArray[i - 1][j + 1] = temp.ToString();
                }
            }

            return $"{string.Concat(stringArray[0])}\n" +
                   $"{string.Concat(stringArray[1])}\n" +
                   $"{string.Concat(stringArray[2])}";
        }
    }
}
