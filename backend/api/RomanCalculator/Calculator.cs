using System;

namespace api.RomanCalculator
{
    public class Calculator
    {
        private static Interpreter _interpreter = new Interpreter();
        
        public static string Evaluate(string input)
        {
            var scanner = new Scanner(input);
            var tokens = scanner.ScanTokens();
            var parser = new Parser(tokens);
            var expression = parser.Parse();
            return _interpreter.Interpret(expression);
        }
    }
}