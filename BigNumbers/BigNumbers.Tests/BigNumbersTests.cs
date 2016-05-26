﻿using System;
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
    }
}
