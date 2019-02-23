using api.RomanCalculator;
using NUnit.Framework;

namespace api.Tests.RomanCalculator
{
    public class CalculatorTests
    {
        [Test]
        public void TestPlainNumber()
        {
            Assert.AreEqual(
                "I",
                Calculator.Evaluate("I")
            );
        }
        
        [Test]
        public void TestPlainNegativeNumber()
        {
            Assert.AreEqual(
                "-I",
                Calculator.Evaluate("-I")
            );
        }

        [Test]
        public void TestAddition()
        {
            Assert.AreEqual(
                "IV",
                Calculator.Evaluate("II + II")
            );
        }

        [Test]
        public void TestAdditionChain()
        {
            Assert.AreEqual(
                "V",
                Calculator.Evaluate("I + II + I + I")
            );
        }

        [Test]
        public void TestSubtraction()
        {
            Assert.AreEqual(
                "0",
                Calculator.Evaluate("I - I")
            );
        }

        [Test]
        public void TestSubtractionChain()
        {
            Assert.AreEqual(
                "X",
                Calculator.Evaluate("XV - III - II")
            );
        }

        [Test]
        public void TestMultiplication()
        {
            Assert.AreEqual(
                "X",
                Calculator.Evaluate("II*V")
            );
        }

        [Test]
        public void TestDivision()
        {
            Assert.AreEqual(
                "X",
                Calculator.Evaluate("C/X")
            );
        }

        [Test]
        public void TestPower()
        {
            Assert.AreEqual(
                "VIII",
                Calculator.Evaluate("II^III")
            );
        }

        [Test]
        public void TestOrderOfOperations()
        {
            Assert.AreEqual(
                "X",
                Calculator.Evaluate("II + IV * II")
            );
        }

        [Test]
        public void TestGrouping()
        {
            Assert.AreEqual(
                "XII",
                Calculator.Evaluate("(II + IV) * II")
            );
        }
    }
}