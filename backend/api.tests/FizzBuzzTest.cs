using NUnit.Framework;

namespace api.Tests
{
    public class FizzBuzzTest
    {
        [Test]
        public void TestEmptySequence()
        {
            Assert.AreEqual(
                new []
                {
                    "FizzBuzz"
                },
                FizzBuzz.GenerateSequence(0)
            );
        }
        
        [Test]
        public void TestNumber1()
        {
            Assert.AreEqual(
                new []
                {
                    "FizzBuzz",
                    "1"
                },
                FizzBuzz.GenerateSequence(1)
            );
        }
        
        [Test]
        public void TestNumber3()
        {
            Assert.AreEqual(
                new []
                {
                    "FizzBuzz",
                    "1",
                    "2",
                    "Fizz"
                },
                FizzBuzz.GenerateSequence(3)
            );
        }
        
        [Test]
        public void TestNumber5()
        {
            Assert.AreEqual(
                new []
                {
                    "FizzBuzz",
                    "1",
                    "2",
                    "Fizz",
                    "4",
                    "Buzz"
                },
                FizzBuzz.GenerateSequence(5)
            );
        }
        
        [Test]
        public void TestNumber15()
        {
            Assert.AreEqual(
                new []
                {
                    "FizzBuzz",
                    "1",
                    "2",
                    "Fizz",
                    "4",
                    "Buzz",
                    "Fizz",
                    "7",
                    "8",
                    "Fizz",
                    "Buzz",
                    "11",
                    "Fizz",
                    "13",
                    "14",
                    "FizzBuzz"
                },
                FizzBuzz.GenerateSequence(15)
            );
        }
    }
}