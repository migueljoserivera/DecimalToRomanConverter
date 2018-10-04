using System;

namespace DecimalToRoman
{
    public static class NumberConverter
    {
        private const int MaximumDecimalRomanNumber = 3000;
        private const int MinimumDecimalRomanNumber = 0;

        private static readonly string[] RomanNumberThousands = { "", "M", "MM", "MMM" };
        private static readonly string[] RomanNumberHundreds = { "", "C", "CC", "CCC", "CD",
                                                            "D", "DC", "DCC", "DCCC", "CM" };
        private static readonly string[] RomanNumberTens = { "", "X", "XX", "XXX", "XL", "L", "LX",
                                                            "LXX", "LXXX", "XC" };
        private static readonly string[] RomanNumberOnes = { "", "I", "II", "III", "IV", "V", "VI",
                                                            "VII", "VIII", "IX" };

        /// <summary>
        ///     Convert a decimal number in roman number
        /// </summary>
        /// <param name="number">Decimal to convert</param>
        /// <returns>
        ///     A roman number
        /// </returns>
        /// <example>
        ///     10 converts to X, 125 converts to CXXV
        /// </example>
        /// <exception cref="System.Exception">
        ///     Is not valid
        /// </exception>
        public static string GetRomanNumberFromDecimal(double number)
        {
            ValidateNumberIsInteger(number);
            ValidateNumberIsPositive(number);
            ValidateNumberIsLessOrEqualThanMaximum(number);

            return IntegerToRomanNumber(Convert.ToInt32(number));
        }

        private static void ValidateNumberIsInteger(double number)
        {
            if ((number % 1) != 0)
            {
                throw new Exception("El numero debe ser un entero.");
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
                throw new Exception(
                        $"El numero debe ser menor que {MaximumDecimalRomanNumber}"
                    );
            }
        }

        private static string IntegerToRomanNumber(int number)
        {
            string romanNumberThousands = GetRomanNumberThousands(number);
            string romanNumberHundreds = GetRomanNumberHundreds(number);
            string romanNumberTens = GetRomanNumberTens(number);
            string romanNumberOnes = GetRomanNumberOnes(number);

            return romanNumberThousands + romanNumberHundreds + romanNumberTens + romanNumberOnes;
        }

        private static string GetRomanNumberThousands(int number)
        {
            return RomanNumberThousands[GetIndexForNumber(number, 1000)];
        }

        private static string GetRomanNumberHundreds(int number)
        {
            return RomanNumberHundreds[GetIndexForNumber(number, 100)];
        }

        private static string GetRomanNumberTens(int number)
        {
            return RomanNumberTens[GetIndexForNumber(number, 10)];
        }

        private static string GetRomanNumberOnes(int number)
        {
            return RomanNumberOnes[GetIndexForNumber(number, 1)];
        }

        private static int GetIndexForNumber(int number, int factor)
        {
            return (number / factor) % 10;
        }
    }
}
