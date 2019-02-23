using api.RomanCalculator;
using NUnit.Framework;

namespace api.Tests.RomanCalculator
{
    public class InterpreterTests
    {
        private Interpreter _interpreter;

        [SetUp]
        public void SetUp()
        {
            _interpreter = new Interpreter();
        }
        
        [Test]
        public void TestLiteralExpression()
        {
            var result = _interpreter.Interpret(
                new LiteralExpression(new Token(TokenType.Number, "IV", 4))
            );
            Assert.AreEqual("IV", result);
        }
        
        [Test]
        public void TestUnaryExpression()
        {
            // -X
            var result = _interpreter.Interpret(
                new UnaryExpression(
                    new Token(TokenType.Minus, "-"),
                    new LiteralExpression(new Token(TokenType.Number, "X", 10))
                )
            );
            Assert.AreEqual("-X", result);
        }
        
        [Test]
        public void TestAddition()
        {
            // I + I
            var result = _interpreter.Interpret(
                new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "I", 1)),
                    new Token(TokenType.Plus, "+"),
                    new LiteralExpression(new Token(TokenType.Number, "I", 1))
                )
            );
            Assert.AreEqual("II", result);
        }
        
        [Test]
        public void TestAdditionChain()
        {
            // I + I + I
            var result = _interpreter.Interpret(
                new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "I", 1)),
                    new Token(TokenType.Plus, "+"),
                    new BinaryExpression(
                        new LiteralExpression(new Token(TokenType.Number, "I", 1)),
                        new Token(TokenType.Plus, "+"),
                        new LiteralExpression(new Token(TokenType.Number, "I", 1))
                    )
                )
            );
            Assert.AreEqual("III", result);
        }
        
        [Test]
        public void TestSubtraction()
        {
            // II - I
            var result = _interpreter.Interpret(
                new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "II", 2)),
                    new Token(TokenType.Minus, "-"),
                    new LiteralExpression(new Token(TokenType.Number, "I", 1))
                )
            );
            Assert.AreEqual("I", result);
        }
        
        [Test]
        public void TestSubtractionChain()
        {
            // I - I - I
            var result = _interpreter.Interpret(
                new BinaryExpression(
                    new BinaryExpression(
                        new LiteralExpression(new Token(TokenType.Number, "I", 1)),
                        new Token(TokenType.Minus, "-"),
                        new LiteralExpression(new Token(TokenType.Number, "I", 1))
                    ),
                    new Token(TokenType.Minus, "-"),
                    new LiteralExpression(new Token(TokenType.Number, "I", 1))
                )
            );
            Assert.AreEqual("-I", result);
        }
        
        [Test]
        public void TestMultiplication()
        {
            // I * II
            var result = _interpreter.Interpret(
                new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "I", 1)),
                    new Token(TokenType.Star, "*"),
                    new LiteralExpression(new Token(TokenType.Number, "II", 2))
                )
            );
            Assert.AreEqual("II", result);
        }
        
        [Test]
        public void TestChainMultiplication()
        {
            // I * II * IV
            var result = _interpreter.Interpret(
                new BinaryExpression(
                    new BinaryExpression(
                        new LiteralExpression(new Token(TokenType.Number, "I", 1)),
                        new Token(TokenType.Star, "*"),
                        new LiteralExpression(new Token(TokenType.Number, "II", 2))
                    ), 
                    new Token(TokenType.Star, "*"),
                    new LiteralExpression(new Token(TokenType.Number, "IV", 4))
                )
            );
            Assert.AreEqual("VIII", result);
        }
        
        [Test]
        public void TestPower()
        {
            // II ^ VI
            var result = _interpreter.Interpret(
                new BinaryExpression(
                    new LiteralExpression(new Token(TokenType.Number, "II", 2)),
                    new Token(TokenType.Hat, "^"),
                    new LiteralExpression(new Token(TokenType.Number, "VI", 6))
                )
            );
            Assert.AreEqual("LXIV", result);
        }
    }
}