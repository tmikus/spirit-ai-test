using System;
using System.Collections.Generic;

namespace api
{
  public class FizzBuzz
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

    static string GetToken(uint number)
    {
      if (number % 5 == 0 && number % 3 == 0)
      {
        return "FizzBuzz";
      }

      if (number % 5 == 0)
      {
        return "Buzz";
      }

      if (number % 3 == 0)
      {
        return "Fizz";
      }

      return number.ToString();
    }
  }
}