using api.RomanCalculator;
using NUnit.Framework;

namespace api.Tests.RomanCalculator
{
    public class ScannerTests
    {
        [Test]
        public void TestNumber()
        {
            // 10
            var scanner = new Scanner("X");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.Number, "X", 10),
                },
                result
            );
        }
        
        [Test]
        public void TestLongNumber()
        {
            // 1120
            var scanner = new Scanner("MCXX");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.Number, "MCXX", 1120),
                },
                result
            );
        }
        
        [Test]
        public void TestNumberAddNumber()
        {
            // 10 + 100
            var scanner = new Scanner("X + C");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.Number, "X", 10),
                    new Token(TokenType.Plus, "+"),
                    new Token(TokenType.Number, "C", 100), 
                },
                result
            );
        }
        
        [Test]
        public void TestNumberAddNumberInParen()
        {
            // (10 + 100)
            var scanner = new Scanner("(X + C)");
            var result = scanner.ScanTokens();
            Assert.AreEqual(
                new []
                {
                    new Token(TokenType.LeftParen, "("),
                    new Token(TokenType.Number, "X", 10),
                    new Token(TokenType.Plus, "+"),
                    new Token(TokenType.Number, "C", 100),
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
                    new Token(TokenType.Number, "MCIX", 1109),
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