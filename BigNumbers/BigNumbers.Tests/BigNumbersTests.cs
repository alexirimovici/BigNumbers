using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigNumbers.Tests
{
    [TestClass]
    public class BigNumbersTests
    {
        [TestMethod]
        public void TwoNumbersAreEqual()
        {
            var arrayForFirstNumber = new byte[] { 2, 4, 7 };
            var firstNumber = new BigNumber(arrayForFirstNumber);
            var secondNumber = new BigNumber("247");

            Assert.AreEqual(firstNumber, secondNumber);
        }

        [TestMethod]
        public void AddTwoNumbersWhenBothArePositive()
        {
        }
    }
}
