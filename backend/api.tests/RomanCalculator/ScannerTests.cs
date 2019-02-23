using api.RomanCalculator;
using NUnit.Framework;

namespace api.Tests.RomanCalculator
{
    public class ScannerTests
    {
        [Test]
        public void TestPlainNumber()
        {
            var scanner = new Scanner("MCXX");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.Number, "MCXX"),
                },
                result
            );
        }
        
        [Test]
        public void TestNumberAddNumber()
        {
            var scanner = new Scanner("X + C");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.Number, "X"),
                    new Token(TokenType.Plus, "+"),
                    new Token(TokenType.Number, "C"), 
                },
                result
            );
        }
        
        [Test]
        public void TestNumberAddNumberInParen()
        {
            var scanner = new Scanner("(X + C)");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.LeftParen, "("),
                    new Token(TokenType.Number, "X"),
                    new Token(TokenType.Plus, "+"),
                    new Token(TokenType.Number, "C"),
                    new Token(TokenType.RightParen, ")"),
                },
                result
            );
        }

        [Test]
        public void TestAllTokens()
        {
            var scanner = new Scanner("(MCIX + - * / ^)");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.LeftParen, "("),
                    new Token(TokenType.Number, "MCIX"),
                    new Token(TokenType.Plus, "+"),
                    new Token(TokenType.Minus, "-"),
                    new Token(TokenType.Star, "*"),
                    new Token(TokenType.Slash, "/"),
                    new Token(TokenType.Hat, "^"),
                    new Token(TokenType.RightParen, ")"), 
                },
                result
            );
        }
    }
}