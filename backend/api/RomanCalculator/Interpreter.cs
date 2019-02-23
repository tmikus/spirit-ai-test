using System;

namespace api.RomanCalculator
{
    public class Interpreter
    {
        public string Interpret(Expression expression)
        {
            return RomanNumerals.FromArabic(expression.Execute());
        }
    }
}