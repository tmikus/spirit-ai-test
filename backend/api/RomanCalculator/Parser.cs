using System;

namespace api.RomanCalculator
{
    public class Parser
    {
        private Token[] _tokens;

        public Parser(Token[] tokens)
        {
            _tokens = tokens;
        }

        public Expression Parse()
        {
            throw new NotImplementedException();
        }
    }
}