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
            var firstNumber = new BigNumber("5633");
            var secondNumber = new BigNumber("23998");
            var res = new BigNumber("29631");

            var result = firstNumber + secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void AddTwoNumbersWhenBothAreNegative()
        {
            var firstNumber = new BigNumber("-99999");
            var secondNumber = new BigNumber("-32455121");
            var res = new BigNumber("-32555120");

            var result = firstNumber + secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void AddTwoNumbersWhenFirstIsPositiveAndSecondIsNegative()
        {
            var firstNumber = new BigNumber("748329");
            var secondNumber = new BigNumber("-43");
            var res = new BigNumber("748286");

            var result = firstNumber + secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void AddTwoNumbersWhenFirstIsNegativeAndSecondIsPositive()
        {
            var firstNumber = new BigNumber("-6999");
            var secondNumber = new BigNumber("39944");
            var res = new BigNumber("32945");

            var result = firstNumber + secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void SubtractTwoNumbersWhenBothAreNegative()
        {
            var firstNumber = new BigNumber("-6999");
            var secondNumber = new BigNumber("-39944");
            var res = new BigNumber("32945");

            var result = firstNumber - secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void MultiplyTwoNumbersWhenBothAreNegative()
        {
            var firstNumber = new BigNumber("-6999");
            var secondNumber = new BigNumber("-39944");
            var res = new BigNumber("279568056");

            var result = firstNumber * secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void MultiplyTwoNumbersWhenFirstIsNegativeAndSecondIsPositive()
        {
            var firstNumber = new BigNumber("-6999");
            var secondNumber = new BigNumber("347888");
            var res = new BigNumber("-2434868112");

            var result = firstNumber * secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideTwoNumbersWhenDivisorIsZero()
        {
            var firstNumber = new BigNumber("-6999");
            var secondNumber = new BigNumber("0");

            var result = firstNumber / secondNumber;
        }

        [TestMethod]
        public void DivideTwoNumbersWhenDividendIsSmallerThanDivisor()
        {
            var firstNumber = new BigNumber("6999");
            var secondNumber = new BigNumber("39944");
            var res = new BigNumber("0");

            var result = firstNumber / secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void DivideTwoNumbersWhenDividendIsLargerThanDivisor()
        {
            var firstNumber = new BigNumber("12996999");
            var secondNumber = new BigNumber("399445");
            var res = new BigNumber("32");

            var result = firstNumber / secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void DivideTwoNumbersWhenDividendIsNegativeAndDivisorIsPositive()
        {
            var firstNumber = new BigNumber("-217899");
            var secondNumber = new BigNumber("39944");
            var res = new BigNumber("-5");

            var result = firstNumber / secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void DivideTwoNumbersWhenDividendIsPositiveAndDivisorIsNegative()
        {
            var firstNumber = new BigNumber("996999");
            var secondNumber = new BigNumber("-39944");
            var res = new BigNumber("-24");

            var result = firstNumber / secondNumber;

            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void DivideTwoNumbersWhenResultIsSubunitaryAndNegative()
        {
            var firstNumber = new BigNumber("6999");
            var secondNumber = new BigNumber("-39944");
            var res = new BigNumber("0");

            var result = firstNumber / secondNumber;

            Assert.AreEqual(res, result);
        }
    }
}
