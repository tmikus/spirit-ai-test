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

        protected bool Equals(Token other)
        {
            return string.Equals(Lexeme, other.Lexeme) && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Token) obj);
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