using System;
using System.Collections.Generic;

namespace api
{
    public class FizzBuzzPinkFlamingo
    {
        public static string[] GenerateSequence(uint endNumber)
        {
            var output = new List<string>();
            for (uint number = 0; number <= endNumber; number++)
            {
                output.Add(GetToken(number));
            }

            return output.ToArray();
        }

        private static string GetToken(uint number)
        {
            if (number % 5 == 0 && number % 3 == 0)
            {
                return IsFibonacciNumber((int) number)
                    ? "Pink Flamingo"
                    : "FizzBuzz";
            }

            if (number % 5 == 0)
            {
                return "Buzz";
            }

            if (number % 3 == 0)
            {
                return "Fizz";
            }

            if (IsFibonacciNumber((int) number))
            {
                return "Flamingo";
            }

            return number.ToString();
        }

        private static bool IsFibonacciNumber(int number)
        {
            return IsPerfectSquare(5 * number * number + 4)
                   || IsPerfectSquare(5 * number * number - 4);
        }

        private static bool IsPerfectSquare(int number)
        {
            var sqrt = Math.Sqrt(number);
            return sqrt % 1 == 0;
        }
    }
}