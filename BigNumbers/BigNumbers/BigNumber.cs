using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    public class BigNumber : IComparable
    {
        internal byte[] data;
        internal int length;
        internal int sign;

        public BigNumber()
        {
            data = new byte[0];
            length = 0;
            sign = 1;
        }

        public BigNumber(byte number, int sign = 1)
        {
            data = new byte[1] { number };
            length = 1;
            this.sign = 1;
        }

        public BigNumber(BigNumber anotherBigNumber)
        {
            length = anotherBigNumber.length;
            sign = anotherBigNumber.sign;
            data = anotherBigNumber.data;
        }

        public BigNumber(byte[] number, int sign = 1)
        {
            this.sign = sign;
            data = new byte[number.Length];
            int baseNumber = 10;
            int lowLimit = 0;
            while (number[lowLimit] == 0)
            {
                lowLimit++;
            }

            for (int i = number.Length - 1; i >= lowLimit; i--)
            {
                if (NumberUtils.IsSymbolInBase(number[i], baseNumber))
                {
                    data[length++] = number[i];
                }
                else
                {
                    throw (new ArithmeticException("Invalid input"));
                }
            }
        }

        public BigNumber(string valueWithChars)
        {
            data = new byte[valueWithChars.Length];
            valueWithChars = valueWithChars.Trim();
            bool hasSign = false;

            if (valueWithChars[0] == '-')
            {
                hasSign = true;
                sign = -1;
            } else if (valueWithChars[0] == '+')
            {
                hasSign = true;
                sign = 1;
            }
            else
            {
                sign = 1;
            }

            var lowLimit = (hasSign ? 1 : 0);

            while (valueWithChars[lowLimit] == '0' && lowLimit < valueWithChars.Length - 1)
            {
                lowLimit++;
            }

            for (int i = valueWithChars.Length - 1; i >= lowLimit; i--)
            {
                byte charValue = (byte)valueWithChars[i];
                if (charValue >= '0' && charValue <= '9')
                {
                    charValue -= (byte)'0';
                }
                else
                {
                    throw (new ArithmeticException("Invalid input"));
                }
                data[length++] = charValue;
            }
        }

        public static BigNumber operator +(BigNumber firstNumber, BigNumber secondNumber)
        {
            BigNumber result = null;
            if (firstNumber.sign == secondNumber.sign)
            {
                result = NumberOperation.Sum(firstNumber, secondNumber);
                result.sign = firstNumber.sign;
            }
            else
            {
                var compareResult = (Abs(firstNumber)).CompareTo(Abs(secondNumber));
                if (compareResult == 1)
                {
                    result = NumberOperation.Diff(firstNumber, secondNumber);
                    result.sign = firstNumber.sign;
                }
                else if (compareResult == -1)
                {
                    result = NumberOperation.Diff(secondNumber, firstNumber);
                    result.sign = secondNumber.sign;
                }
                else
                {
                    result = new BigNumber(0);
                }
            }
            return result;
        }

        public static BigNumber operator -(BigNumber firstNumber, BigNumber secondNumber)
        {
            return firstNumber + Negative(secondNumber);
        }

        public static BigNumber operator *(BigNumber firstNumber, BigNumber secondNumber)
        {
            BigNumber result = new BigNumber();
            if (Abs(firstNumber) > Abs(secondNumber))
            {
                result = NumberOperation.Multiply(Abs(firstNumber), Abs(secondNumber));
            }
            else
            {
                result = NumberOperation.Multiply(Abs(secondNumber), Abs(firstNumber));
            }

            if (firstNumber.sign != secondNumber.sign)
            {
                result.sign = -1;
            }

            return result;
        }

        public static BigNumber operator /(BigNumber firstNumber, BigNumber secondNumber)
        {
            if (NumberUtils.IsZero(secondNumber))
            {
                throw new DivideByZeroException();
            }
            var result = NumberOperation.Divide(Abs(firstNumber), Abs(secondNumber));

            if (firstNumber.sign != secondNumber.sign)
            {
                result.sign = -1;
            }

            return result;
        }

        private static BigNumber Negative(BigNumber numberToNegate)
        {
            var result = new BigNumber(numberToNegate);
            result.sign = 0 - numberToNegate.sign;
            return result;
        }

        private static BigNumber Abs(BigNumber number)
        {
            var result = new BigNumber(number);
            result.sign = 1;
            return result;
        }

        public static bool operator ==(BigNumber firstNumber, BigNumber secondNumber)
        {
            return firstNumber.Equals(secondNumber);
        }

        public static bool operator !=(BigNumber firstNumber, BigNumber secondNumber)
        {
            return !firstNumber.Equals(secondNumber);
        }

        public static bool operator >(BigNumber firstNumber, BigNumber secondNumber)
        {
            return firstNumber.CompareTo(secondNumber) == 1;
        }

        public static bool operator <(BigNumber firstNumber, BigNumber secondNumber)
        {
            return firstNumber.CompareTo(secondNumber) == -1;
        }

        public static bool operator >=(BigNumber firstNumber, BigNumber secondNumber)
        {
            var compareResult = firstNumber.CompareTo(secondNumber);
            return compareResult == 1 || compareResult == 0;
        }

        public static bool operator <=(BigNumber firstNumber, BigNumber secondNumber)
        {
            var compareResult = firstNumber.CompareTo(secondNumber);
            return compareResult == -1 || compareResult == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BigNumber number = obj as BigNumber;
            if ((System.Object)number == null)
            {
                return false;
            }

            return this.Equals(number);
        }

        public bool Equals(BigNumber number)
        {
            if ((object)number == null)
            {
                return false;
            }

            if (NumberUtils.IsZero(this) && NumberUtils.IsZero(number))
            {
                return true;
            }

            if (sign != number.sign || length != number.length)
            {
                return false;
            }
            for (int i = 0; i < length; i++)
            {
                if (data[i] != number.data[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = (hash * 23) + length.GetHashCode();
            hash = (hash * 23) + sign.GetHashCode();
            for (int i = 0; i < length; i++)
            {
                hash = (hash * 7) + data[i].GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            StringBuilder number = new StringBuilder();
            if (sign < 0)
            {
                number.Append("-");
            }
            if (length == 0)
            {
                number.Append(0);
            }
            for (int i = length - 1; i >= 0; i--)
            {
                number.Append(data[i]);
            }
            return number.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            BigNumber secondNumber = obj as BigNumber;
            if (secondNumber != null)
            {
                if (sign > secondNumber.sign)
                {
                    return 1;
                }
                else if (sign < secondNumber.sign)
                {
                    return -1;
                }
                else
                {
                    if (length > secondNumber.length)
                    {
                        return (sign == 1) ? 1 : -1;
                    }
                    else if (length < secondNumber.length)
                    {
                        return (sign == 1) ? -1 : 1;
                    }
                    else
                    {
                        for (int i = length - 1; i >= 0; i--)
                        {
                            if (data[i] > secondNumber.data[i])
                            {
                                return (sign == 1) ? 1 : -1;
                            }
                            else if (data[i] < secondNumber.data[i])
                            {
                                return (sign == 1) ? -1 : 1;
                            }
                        }
                        return 0;
                    }
                }
            }
            else
            {
                throw new ArgumentException("Object is not a BigNumber");
            }
        }
    }
}
