using NUnit.Framework;

namespace api.Tests
{
    public class FizzBuzzPinkFlamingoTest
    {
        [Test]
        public void TestEmptySequence()
        {
            Assert.AreEqual(
                new []
                {
                    "Pink Flamingo"
                },
                FizzBuzzPinkFlamingo.GenerateSequence(0)
            );
        }
        
        [Test]
        public void TestNumber1()
        {
            Assert.AreEqual(
                new []
                {
                    "Pink Flamingo",
                    "Flamingo"
                },
                FizzBuzzPinkFlamingo.GenerateSequence(1)
            );
        }
        
        [Test]
        public void TestNumber3()
        {
            Assert.AreEqual(
                new []
                {
                    "Pink Flamingo",
                    "Flamingo",
                    "Flamingo",
                    "Fizz"
                },
                FizzBuzzPinkFlamingo.GenerateSequence(3)
            );
        }
        
        [Test]
        public void TestNumber5()
        {
            Assert.AreEqual(
                new []
                {
                    "Pink Flamingo",
                    "Flamingo",
                    "Flamingo",
                    "Fizz",
                    "4",
                    "Buzz"
                },
                FizzBuzzPinkFlamingo.GenerateSequence(5)
            );
        }
        
        [Test]
        public void TestNumber15()
        {
            Assert.AreEqual(
                new []
                {
                    "Pink Flamingo",
                    "Flamingo",
                    "Flamingo",
                    "Fizz",
                    "4",
                    "Buzz",
                    "Fizz",
                    "7",
                    "Flamingo",
                    "Fizz",
                    "Buzz",
                    "11",
                    "Fizz",
                    "Flamingo",
                    "14",
                    "FizzBuzz"
                },
                FizzBuzzPinkFlamingo.GenerateSequence(15)
            );
        }
    }
}