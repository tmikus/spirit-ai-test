using System;
using Microsoft.AspNetCore.DataProtection;

namespace api.RomanCalculator
{
    public class Parser
    {
        private int _current = 0;
        private Token[] _tokens;

        public Parser(Token[] tokens)
        {
            _tokens = tokens;
        }

        private Expression Addition()
        {
            var expr = Multiplication();
            while (MatchToken(TokenType.Plus, TokenType.Minus))
            {
                var oper = PreviousToken();
                var right = Multiplication();
                expr = new BinaryExpression(expr, oper, right);
            }

            return expr;
        }

        private void Advance()
        {
            _current++;
        }
        
        private bool CheckToken(TokenType tokenType)
        {
            if (IsAtEnd()) return false;
            return PeekToken().Type == tokenType;
        }

        private void ConsumeToken(TokenType tokenType, string errorMessage)
        {
            if (CheckToken(tokenType))
            {
                Advance();
                return;
            }
            throw new InvalidOperationException(errorMessage);
        }

        private Expression Expression() => Addition();
        
        private bool IsAtEnd()
        {
            return _current >= _tokens.Length;
        }
        
        private bool MatchToken(params TokenType[] tokenTypes)
        {
            foreach (var tokenType in tokenTypes)
            {
                if (CheckToken(tokenType))
                {
                    Advance();
                    return true;
                }
            }

            return false;
        }

        private Expression Multiplication()
        {
            var expr = Unary();
            while (MatchToken(TokenType.Star, TokenType.Slash))
            {
                var oper = PreviousToken();
                var right = Multiplication();
                expr = new BinaryExpression(expr, oper, right);
            }

            return expr;
        }

        public Expression Parse()
        {
            return Expression();
        }

        private Token PeekToken() => _tokens[_current];

        private Token PreviousToken() => _tokens[_current - 1];

        private Expression Primary()
        {
            if (MatchToken(TokenType.Number))
            {
                return new LiteralExpression(PreviousToken());
            }

            if (MatchToken(TokenType.LeftParen))
            {
                var expr = Expression();
                ConsumeToken(TokenType.RightParen, "Expected ')' after expression.");
                return new GroupingExpression(expr);
            }
            
            throw new InvalidOperationException("Expected expression.");
        }

        private Expression Unary()
        {
            if (MatchToken(TokenType.Plus, TokenType.Minus))
            {
                var oper = PreviousToken();
                var expr = Unary();
                return new UnaryExpression(oper, expr);
            }

            return Primary();
        }
    }
}