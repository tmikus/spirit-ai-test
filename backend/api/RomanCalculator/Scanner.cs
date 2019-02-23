using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.RomanCalculator
{
    public class Scanner
    {
        private string _source;
        private List<Token> _tokens = new List<Token>();
        private int _start = 0;
        private int _current = 0;

        public Scanner(string source)
        {
            _source = source;
        }

        private void AddToken(TokenType type)
        {
            var lexeme = _source.Substring(_start, _current - _start);
            _tokens.Add(
                type == TokenType.Number
                ? new Token(type, lexeme, RomanNumerals.ToArabic(lexeme))
                : new Token(type, lexeme)
            );
        }

        private void Advance()
        {
            _current++;
        }

        private char GetChar()
        {
            if (IsAtEnd()) return '\0';
            return _source[_current];
        }
        
        private char GetCharAndAdvance()
        {
            var result = GetChar();
            Advance();
            return result;
        }
        
        private bool IsAtEnd()
        {
            return _current >= _source.Length;
        }

        private bool IsRomanNumber(char character)
        {
            switch (character)
            {
                case 'I':
                case 'V':
                case 'X':
                case 'L':
                case 'C':
                case 'D':
                case 'M':
                    return true;
            }

            return false;
        }

        private void ScanNumber()
        {
            while (IsRomanNumber(GetChar()))
            {
                Advance();
            }
            
            AddToken(TokenType.Number);
        }

        private void ScanToken()
        {
            var character = GetCharAndAdvance();
            switch (character)
            {
                case '(':
                    AddToken(TokenType.LeftParen);
                    break;
                case ')':
                    AddToken(TokenType.RightParen);
                    break;
                case '+':
                    AddToken(TokenType.Plus);
                    break;
                case '-':
                    AddToken(TokenType.Minus);
                    break;
                case '*':
                    AddToken(TokenType.Star);
                    break;
                case '/':
                    AddToken(TokenType.Slash);
                    break;
                case '^':
                    AddToken(TokenType.Hat);
                    break;
                case ' ':
                    // Ignore whitespace
                    break;
                default:
                    if (IsRomanNumber(character))
                    {
                        ScanNumber();
                    }
                    else
                    {
                        throw new ArgumentException("Unexpected character");
                    }
                    break;
            }
        }

        public Token[] ScanTokens()
        {
            _tokens.Clear(); // Just to make sure no-one is calling this function twice...
            
            while (!IsAtEnd())
            {
                _start = _current;
                ScanToken();
            }

            return _tokens.ToArray();
        }
    }
}