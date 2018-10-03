using System;

// This is a namespace for the class
namespace DecimalToRoman
{
    // This class is an utility for convert numbers from a format to other
    public static class NumberConverter
    {
        // Maximum decimal number for convert to roman numbers
        private const int MaximumDecimalRomanNumber = 3000;
        private const int MinimumDecimalRomanNumber = 0;

        private static readonly string[] RomanThousands = { "", "M", "MM", "MMM" };
        private static readonly string[] RomanHundreds = { "", "C", "CC", "CCC", "CD",
                                                            "D", "DC", "DCC", "DCCC", "CM" };

        private static readonly string[] RomanTens = { "", "X", "XX", "XXX", "XL", "L", "LX",
                                                            "LXX", "LXXX", "XC" };

        private static readonly string[] RomanOnes = { "", "I", "II", "III", "IV", "V", "VI",
                                                            "VII", "VIII", "IX" };

        public static string GetRomanNumberFromDecimal(double number)
        {
            ValidateNumberIsInteger(number);
            ValidateNumberIsPositive(number);
            ValidateNumberIsLessOrEqualThanMaximum(number);

            return IntToRoman(Convert.ToInt32(number));
        }

        private static void ValidateNumberIsInteger(double number)
        {
            if ((number % 1) != 0)
            {
                throw new Exception("El numero debe ser un entero");
            }
        }

        private static void ValidateNumberIsPositive(double number)
        {
            if (number < MinimumDecimalRomanNumber)
            {
                throw new Exception("El numero debe ser un numero positivo");
            }
        }

        private static void ValidateNumberIsLessOrEqualThanMaximum(double number)
        {
            if (number > MaximumDecimalRomanNumber)
            {
                throw new Exception($"El numero debe ser menor que {MaximumDecimalRomanNumber}");
            }
        }

        private static string IntToRoman(int number)
        {
            string romanThousands = GetRomanThousands(number);
            string romanHundreds = GetRomanHundreds(number);
            string romanTens = GetRomanTens(number);
            string romanOnes = GetRomanOnes(number);
            return romanThousands + romanHundreds + romanTens + romanOnes;
        }

        private static string GetRomanThousands(int number)
        {
            return RomanThousands[GetIndexForNumber(number, 1000)];
        }

        private static string GetRomanHundreds(int number)
        {
            return RomanHundreds[GetIndexForNumber(number, 100)];
        }

        private static string GetRomanTens(int number)
        {
            return RomanTens[GetIndexForNumber(number, 10)];
        }

        private static string GetRomanOnes(int number)
        {
            return RomanOnes[GetIndexForNumber(number, 1)];
        }

        private static int GetIndexForNumber(int number, int factor)
        {
            return (number / factor) % 10;
        }
    }
}
