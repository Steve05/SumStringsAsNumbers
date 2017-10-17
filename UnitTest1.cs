using System;
using System.Linq;
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
        public void input_4444444444131151201344081895336534324865_1_should_return_4444444444131151201344081895336534324866()
        {
            AssertSumStringsShouldBe("4444444444131151201344081895336534324866", "4444444444131151201344081895336534324865", "1");
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
            var arrayA = a.Length < b.Length ? a.ToCharArray() : b.ToCharArray();

            var arrayB = a.Length < b.Length ? b.ToCharArray() : a.ToCharArray();

            var temp = 0;

            var result = string.Empty;

            var arrayBIndex = arrayB.Length;

            for (int i = arrayA.Length - 1; i >= 0 ; i--)
            {
                arrayBIndex--;

                var arraySum = int.Parse(arrayA[i].ToString()) + int.Parse(arrayB[arrayBIndex].ToString()) + temp;

                temp = arraySum > 9 ? 1 : 0;

                result += (arraySum % 10);
            }

            for (int i = arrayB.Length - arrayA.Length - 1; i >= 0 ; i--)
            {
                arrayBIndex--;

                var arraySum = int.Parse(arrayB[arrayBIndex].ToString()) + temp;

                temp = arraySum > 9 ? 1 : 0;

                result += (arraySum % 10);
            }

            result = ReverseString(result).First() == '0' && temp == 0 ? ReverseString(result).Substring(1) : ReverseString(result);

            return temp == 1 ? "1" + result : result;
        }

        private string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();

            Array.Reverse(arr);

            return new string(arr);
        }

    }
}
