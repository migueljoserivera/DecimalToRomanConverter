using System;
using Xunit;

namespace DecimalToRoman.Tests
{
    public class TestNumberConverter
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("VII", 7)]
        [InlineData("VIII", 8)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("XXI", 21)]
        [InlineData("XXX", 30)]
        [InlineData("XL", 40)]
        [InlineData("L", 50)]
        [InlineData("LX", 60)]
        [InlineData("LXX", 70)]
        [InlineData("LXXX", 80)]
        [InlineData("XC", 90)]
        [InlineData("C", 100)]
        [InlineData("CC", 200)]
        [InlineData("CCC", 300)]
        [InlineData("CD", 400)]
        [InlineData("D", 500)]
        [InlineData("DC", 600)]
        [InlineData("DCC", 700)]
        [InlineData("DCCC", 800)]
        [InlineData("CM", 900)]
        [InlineData("M", 1000)]
        [InlineData("MM", 2000)]
        [InlineData("MMM", 3000)]
        public void TestDecimalToRoman_numberToTestMustBeAsExpected(string expected, double numberToTest)
        {
            Assert.Equal(expected, NumberConverter.GetRomanNumberFromDecimal(numberToTest));
        }

        [Theory]
        [InlineData(1.5, "El numero debe ser un entero.")]
        [InlineData(-1, "El numero debe ser un numero positivo")]
        [InlineData(3001, "El numero debe ser menor que 3000")]
        public void TestDecimalToRomanWhenNumberIsNotCorrect_mustDispatchCorrectExceptionMessage(double numberToTest, string exceptionMessage)
        {
            Action romanNumberToDecimalAction = () =>
            {
                NumberConverter.GetRomanNumberFromDecimal(numberToTest);
            };

            var exception = Assert.Throws<Exception>(romanNumberToDecimalAction);
            Assert.Equal(exceptionMessage, exception.Message);
        }
    }
}
