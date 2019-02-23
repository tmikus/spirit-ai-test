namespace api.RomanCalculator
{
    public class Token
    {
        public string Lexeme { get; }
        public TokenType Type { get; }
        
        public int? Value { get; }
        

        public Token(TokenType type, string lexeme, int? value = null)
        {
            Type = type;
            Lexeme = lexeme;
            Value = value;
        }

        protected bool Equals(Token other)
        {
            return string.Equals(Lexeme, other.Lexeme) && Type == other.Type && Value == other.Value;
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
                var hashCode = (Lexeme != null ? Lexeme.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Type;
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                return hashCode;
            }
        }
    }
}