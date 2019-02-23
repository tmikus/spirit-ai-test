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
    }
}