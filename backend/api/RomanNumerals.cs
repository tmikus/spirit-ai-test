using System;

namespace api
{
    public class RomanNumerals
    {
        public static string FromArabic(int number)
        {
            throw new NotImplementedException();
        }

        private static int GetRomanNumeralValue(char numeral)
        {
            switch (numeral)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default:
                    throw new ArgumentException($"Invalid roman numeral supplied: {numeral}");
            }
        }
        
        public static int ToArabic(string numeral)
        {
            int result = 0;
            for (var index = 0; index < numeral.Length; index++)
            {
                var currentSymbol = GetRomanNumeralValue(numeral[index]);
                if (index + 1 >= numeral.Length)
                {
                    result += currentSymbol;
                    break;
                }

                var nextSymbol = GetRomanNumeralValue(numeral[index + 1]);
                if (currentSymbol >= nextSymbol)
                {
                    result += currentSymbol;
                }
                else
                {
                    result += nextSymbol - currentSymbol;
                    index += 1; // Manually advance the index as we've consumed two tokens in one turn
                }
            }

            return result;
        }
    }
}