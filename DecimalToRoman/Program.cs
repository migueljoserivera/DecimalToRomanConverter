using System;

namespace DecimalToRoman
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = RequestDecimalNumber();
            string conversionResult = GetConversionResult(inputNumber);
            WriteAndWait(conversionResult);
        }

        private static string RequestDecimalNumber()
        {
            Console.WriteLine("Ingrese un numero decimal para convertirlo a notacion romana");
            return Console.ReadLine();
        }

        private static string GetConversionResult(string inputNumber)
        {
            try
            {
                double decimalNumber = Convert.ToDouble(inputNumber);
                return NumberConverter.GetRomanNumberFromDecimal(decimalNumber);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private static void WriteAndWait(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
