namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            return numbers == "" ? 0 : int.Parse(numbers);
        }
    }
}
