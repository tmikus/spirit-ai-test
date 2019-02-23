namespace api.RomanCalculator
{
    public class Token
    {
        public string Lexeme { get; }
        public TokenType Type { get; }

        public Token(TokenType type, string lexeme)
        {
            Type = type;
            Lexeme = lexeme;
        }

        public override bool Equals(object obj)
        {
            return obj is Token token && Equals(token);
        }

        private bool Equals(Token other)
        {
            return string.Equals(Lexeme, other.Lexeme) && Type == other.Type;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Lexeme.GetHashCode() * 397) ^ (int) Type;
            }
        }
    }
}