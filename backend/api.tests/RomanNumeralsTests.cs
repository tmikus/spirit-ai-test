using NUnit.Framework;

namespace api.Tests
{
    public class RomanNumeralsToArabicTests
    {
        [Test]
        public void TestI()
        {
            Assert.AreEqual(
                1,
                RomanNumerals.ToArabic("I")
            );
        }

        [Test]
        public void TestII()
        {
            Assert.AreEqual(
                2,
                RomanNumerals.ToArabic("II")
            );
        }

        [Test]
        public void TestIV()
        {
            Assert.AreEqual(
                4,
                RomanNumerals.ToArabic("IV")
            );
        }

        [Test]
        public void TestV()
        {
            Assert.AreEqual(
                5,
                RomanNumerals.ToArabic("V")
            );
        }

        [Test]
        public void TestVI()
        {
            Assert.AreEqual(
                6,
                RomanNumerals.ToArabic("VI")
            );
        }

        [Test]
        public void TestIX()
        {
            Assert.AreEqual(
                9,
                RomanNumerals.ToArabic("IX")
            );
        }

        [Test]
        public void TestX()
        {
            Assert.AreEqual(
                10,
                RomanNumerals.ToArabic("X")
            );
        }

        [Test]
        public void TestXI()
        {
            Assert.AreEqual(
                11,
                RomanNumerals.ToArabic("XI")
            );
        }

        [Test]
        public void TestL()
        {
            Assert.AreEqual(
                50,
                RomanNumerals.ToArabic("L")
            );
        }

        [Test]
        public void TestC()
        {
            Assert.AreEqual(
                100,
                RomanNumerals.ToArabic("C")
            );
        }

        [Test]
        public void TestD()
        {
            Assert.AreEqual(
                500,
                RomanNumerals.ToArabic("D")
            );
        }

        [Test]
        public void TestM()
        {
            Assert.AreEqual(
                1000,
                RomanNumerals.ToArabic("M")
            );
        }

        [Test]
        public void TestXXXIX()
        {
            Assert.AreEqual(
                39,
                RomanNumerals.ToArabic("XXXIX")
            );
        }

        [Test]
        public void TestCCXLVI()
        {
            Assert.AreEqual(
                246,
                RomanNumerals.ToArabic("CCXLVI")
            );
        }

        [Test]
        public void TestMLXVI()
        {
            Assert.AreEqual(
                1066,
                RomanNumerals.ToArabic("MLXVI")
            );
        }

        [Test]
        public void TestMMXIX()
        {
            Assert.AreEqual(
                2019,
                RomanNumerals.ToArabic("MMXIX")
            );
        }
    }

    public class RomanNumeralsFromArabicTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(
                "I",
                RomanNumerals.FromArabic(1)
            );
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(
                "II",
                RomanNumerals.FromArabic(2)
            );
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual(
                "IV",
                RomanNumerals.FromArabic(4)
            );
        }

        [Test]
        public void Test5()
        {
            Assert.AreEqual(
                "V",
                RomanNumerals.FromArabic(5)
            );
        }

        [Test]
        public void Test6()
        {
            Assert.AreEqual(
                "VI",
                RomanNumerals.FromArabic(6)
            );
        }

        [Test]
        public void Test9()
        {
            Assert.AreEqual(
                "IX",
                RomanNumerals.FromArabic(9)
            );
        }

        [Test]
        public void Test10()
        {
            Assert.AreEqual(
                "X",
                RomanNumerals.FromArabic(10)
            );
        }

        [Test]
        public void Test11()
        {
            Assert.AreEqual(
                "XI",
                RomanNumerals.FromArabic(11)
            );
        }

        [Test]
        public void Test50()
        {
            Assert.AreEqual(
                "L",
                RomanNumerals.FromArabic(50)
            );
        }

        [Test]
        public void Test100()
        {
            Assert.AreEqual(
                "C",
                RomanNumerals.FromArabic(100)
            );
        }

        [Test]
        public void Test500()
        {
            Assert.AreEqual(
                "D",
                RomanNumerals.FromArabic(500)
            );
        }

        [Test]
        public void Test1000()
        {
            Assert.AreEqual(
                "M",
                RomanNumerals.FromArabic(1000)
            );
        }

        [Test]
        public void Test39()
        {
            Assert.AreEqual(
                "XXXIX",
                RomanNumerals.FromArabic(39)
            );
        }

        [Test]
        public void Test246()
        {
            Assert.AreEqual(
                "CCXLVI",
                RomanNumerals.FromArabic(246)
            );
        }

        [Test]
        public void Test1066()
        {
            Assert.AreEqual(
                "MLXVI",
                RomanNumerals.FromArabic(1066)
            );
        }

        [Test]
        public void Test2019()
        {
            Assert.AreEqual(
                "MMXIX",
                RomanNumerals.FromArabic(2019)
            );
        }
    }
}