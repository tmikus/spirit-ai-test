using api.RomanCalculator;
using NUnit.Framework;

namespace api.Tests.RomanCalculator
{
    public class ParserTests
    {
        [Test]
        public void TestLiteral()
        {
            // X
            var parser = new Parser(new[]
            {
                new Token(TokenType.Number, "X", 10),
            });
            var result = parser.Parse();
            Assert.AreEqual(
                new LiteralExpression(new Token(TokenType.Number, "X", 10)),
                result
            );
        }
        
        [Test]
        public void TestUnary()
        {
            // -X
            var parser = new Parser(new[]
            {
                new Token(TokenType.Minus, "-"), 
                new Token(TokenType.Number, "X", 10),
            });
            var result = parser.Parse();
            Assert.AreEqual(
                new UnaryExpression(
                    new Token(TokenType.Minus, "-"),
                    new LiteralExpression(new Token(TokenType.Number, "X", 10))
                ),
                result
            );
        }

        [Test]
        public void TestBinary()
        {
            // V + X
            var parser = new Parser(new[]
            {
                new Token(TokenType.Number, "V", 5), 
                new Token(TokenType.Plus, "+"), 
                new Token(TokenType.Number, "X", 10),
            });
            var result = parser.Parse();
            Assert.AreEqual(
                  new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "V", 5)),
                    new Token(TokenType.Plus, "+"),
                    new LiteralExpression(new Token(TokenType.Number, "X", 10))
                ),
                result
            );
        }

        [Test]
        public void TestBinaryMultiplicationAndAddition()
        {
            // V - I * X
            var parser = new Parser(new[]
            {
                new Token(TokenType.Number, "V", 5), 
                new Token(TokenType.Minus, "-"), 
                new Token(TokenType.Number, "I", 1),
                new Token(TokenType.Star, "*"),
                new Token(TokenType.Number, "X", 10), 
            });
            var result = parser.Parse();
            Assert.AreEqual(
                new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "V", 5)),
                    new Token(TokenType.Minus, "-"), 
                    new BinaryExpression(
                        new LiteralExpression(new Token(TokenType.Number, "I", 1)),
                        new Token(TokenType.Star, "*"),
                        new LiteralExpression(new Token(TokenType.Number, "X", 10))
                    )
                ),
                result
            );
        }

        [Test]
        public void TestPower()
        {
            var parser = new Parser(new []
            {
                new Token(TokenType.Number, "V", 5),
                new Token(TokenType.Hat, "^"), 
                new Token(TokenType.Number, "II", 2), 
            });
            var result = parser.Parse();
            Assert.AreEqual(
                new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "V", 5)),
                    new Token(TokenType.Hat, "^"),
                    new LiteralExpression(new Token(TokenType.Number, "II", 2))
                ),
                result
            );
        }

        [Test]
        public void TestGrouping()
        {
            // (V - I) * X
            var parser = new Parser(new[]
            {
                new Token(TokenType.LeftParen, "("), 
                new Token(TokenType.Number, "V", 5), 
                new Token(TokenType.Minus, "-"), 
                new Token(TokenType.Number, "I", 1),
                new Token(TokenType.RightParen, ")"), 
                new Token(TokenType.Star, "*"),
                new Token(TokenType.Number, "X", 10), 
            });
            var result = parser.Parse();
            Assert.AreEqual(
                new BinaryExpression(
                    new GroupingExpression(
                        new BinaryExpression(
                            new LiteralExpression(new Token(TokenType.Number, "V", 5)),
                            new Token(TokenType.Minus, "-"),
                            new LiteralExpression(new Token(TokenType.Number, "I", 1))
                        )
                    ),
                    new Token(TokenType.Star, "*"),
                    new LiteralExpression(new Token(TokenType.Number, "X", 10))
                ),
                result
            );
        }
    }
}