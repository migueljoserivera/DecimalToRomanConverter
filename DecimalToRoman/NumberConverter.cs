using System;

namespace DecimalToRoman
{
    public static class NumberConverter
    {
        private const int MaximumDecimalNumber = 3000;
        private const int MinimumDecimalNumber = 0;

        private static readonly string[] RomanThousands = { "", "M", "MM", "MMM" };
        private static readonly string[] RomanHundreds = { "", "C", "CC", "CCC", "CD",
                                                            "D", "DC", "DCC", "DCCC", "CM" };

        private static readonly string[] RomanTen = { "", "X", "XX", "XXX", "XL", "L", "LX",
                                                            "LXX", "LXXX", "XC" };

        private static readonly string[] RomanOnes = { "", "I", "II", "III", "IV", "V", "VI",
                                                            "VII", "VIII", "IX" };

        public static string GetRomanNumberFromDecimal(double number)
        {
            ValidateNumberIsInteger(number);
            ValidateNumberIsPositive(number);
            ValidateNumberIsLessOrEqualThanMaximum(number);

            return "";
        }

        private static void ValidateNumberIsInteger(double number)
        {
            if ((number % 1) == 0)
            {
                throw new Exception("El numero debe ser un entero");
            }
        }

        private static void ValidateNumberIsLessOrEqualThanMaximum(double number)
        {
            if (number < MaximumDecimalNumber)
            {
                throw new Exception($"El numero debe ser menor que {MaximumDecimalNumber}");
            }
        }

        private static void ValidateNumberIsPositive(double number)
        {
            if (number > MinimumDecimalNumber)
            {
                throw new Exception("El numero debe ser un numero positivo");
            }
        }

        private string IntToRoman(int number)
        {
            string romanThousands = GetRomanThousands(number);
            string romanHundreds = GetRomanHundreds(number);
            roman += ten[(int)(num / 10) % 10];
            roman += ones[num % 10];

            return romanThousands + romanHundreds;
        }

        private static string GetRomanThousands(int number)
        {
            return RomanThousands[(int)(number / 1000) % 10];
        }

        private static string GetRomanHundreds(int number)
        {
            return RomanHundreds[(int)(number / 100) % 10];
        }
    }
}
