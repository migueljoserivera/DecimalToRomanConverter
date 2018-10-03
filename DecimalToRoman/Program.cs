using System;

namespace DecimalToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = RequestDecimalNumber();
            string romanNumber = GetRomanNumberFromDecimal(inputNumber);
            WriteAndWait(romanNumber);
        }

        private static string RequestDecimalNumber()
        {
            Console.WriteLine("Ingrese un numero decimal para convertirlo a notacion romana");
            return Console.ReadLine();
        }

        private static string GetRomanNumberFromDecimal(string inputNumber)
        {
            double decimalNumber = Convert.ToDouble(inputNumber);
            return NumberConverter.GetRomanNumberFromDecimal(decimalNumber);
        }

        private static void WriteAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
