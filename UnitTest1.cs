using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SumStringsAsNumbers
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void input_123_456_should_return_579()
        {
            AssertSumStringsShouldBe("579", "123", "456");
        }

        [TestMethod]
        public void input_N123_456_should_return_579()
        {
            AssertSumStringsShouldBe("333", "-123", "456");
        }

        [TestMethod]
        public void input_empty_should_return_zero()
        {
            AssertSumStringsShouldBe("0", "", "");
        }

        private static void AssertSumStringsShouldBe(string expected, string strNum1, string strNum2)
        {
            var kata = new Kata();
            var actual = kata.sumStrings(strNum1, strNum2);
            Assert.AreEqual(expected, actual);
        }
    }

    public class Kata
    {
        public string sumStrings(string a, string b)
        {
            int.TryParse(a, out var num1);

            int.TryParse(b, out var num2);

            return (num1 + num2).ToString();
        }

    }
}
