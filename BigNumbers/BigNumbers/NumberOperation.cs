using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    class NumberOperation
    {
        public static BigNumber Sum(BigNumber firstNumber, BigNumber secondNumber)
        {
            BigNumber result = new BigNumber();
            int baseNumber = 10;

            result.length = (firstNumber.length > secondNumber.length) ? firstNumber.length : secondNumber.length;
            result.data = new byte[result.length + 1];

            int carry = 0;

            for (int i = 0; i < result.length; i++)
            {
                int first = 0, second = 0;
                if (i < firstNumber.length)
                { first = (int)firstNumber.data[i]; }
                if (i < secondNumber.length)
                { second = (int)secondNumber.data[i]; }
                int sum = first + second + carry;
                carry = sum / baseNumber;
                result.data[i] = (byte)(sum % baseNumber);
            }

            if (carry != 0)
            {
                result.data[result.length++] = (byte)carry;
            }
            return result;
        }

        public static BigNumber Diff(BigNumber firstNumber, BigNumber secondNumber)
        {
            BigNumber result = new BigNumber();
            int baseNumber = 10;

            var maxLength = (firstNumber.length > secondNumber.length) ? firstNumber.length : secondNumber.length;
            result.data = new byte[maxLength];

            int carry = 0;

            for (int i = 0; i < maxLength; i++)
            {
                int first = 0, second = 0;
                if (i < firstNumber.length)
                { first = (int)firstNumber.data[i]; }
                if (i < secondNumber.length)
                { second = (int)secondNumber.data[i]; }
                int diff = first - second - carry;
                carry = diff < 0 ? 1 : 0;
                result.data[result.length++] = (byte)(diff < 0 ? (baseNumber + diff) : diff);
            }
            NumberUtils.RemoveZerosFromBeginningOfNumber(result);
            return result;
        }

        public static BigNumber Multiply(BigNumber firstNumber, BigNumber secondNumber)
        {
            var result = new BigNumber();

            int baseNumber = 10;

            var maxlength = firstNumber.length > secondNumber.length ? firstNumber.length : secondNumber.length;
            result.length = 2 * maxlength + 1;
            result.data = new byte[result.length];

            for (int i = 0; i <= maxlength; i++)
            {
                int carry = 0;
                for (int j = 0; j <= maxlength; j++)
                {
                    int first = 0, second = 0;
                    if (j < firstNumber.length)
                    {
                        first = (int)firstNumber.data[j];
                    }
                    if (i < secondNumber.length)
                    {
                        second = (int)secondNumber.data[i];
                    }

                    int sum = (first * second) + (int)result.data[i + j] + carry;
                    carry = sum / baseNumber;
                    result.data[i + j] = (byte)(sum % baseNumber);
                }
            }
            NumberUtils.RemoveZerosFromBeginningOfNumber(result);
            return result;
        }

        public static BigNumber Divide(BigNumber firstNumber, BigNumber secondNumber)
        {
            int quotient = 0;
            var dividend = new BigNumber(firstNumber);

            while (dividend >= secondNumber)
            {
                dividend = dividend - secondNumber;
                quotient++;
            }
            var result = new BigNumber(quotient.ToString());
            return result;
        }
    }
}
