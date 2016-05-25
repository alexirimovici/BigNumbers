using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    public class BigNumber
    {
        byte[] data;
        int length;
        int sign;

        public BigNumber()
        {
            data = new byte[1];
            length = 0;
            sign = 1;
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
            int lowLimit = 0;
            while (number[lowLimit] == 0)
            {
                lowLimit++;
            }

            for (int i = number.Length - 1; i >= lowLimit; i--)
            {
                if (number[i] >= 0 || number[i] <= 9)
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

        public override string ToString()
        {
            StringBuilder number = new StringBuilder();
            if (sign < 0)
            {
                number.Append("-");
            }
            for (int i = length - 1; i >= 0; i--)
            {
                number.Append(data[i]);
            }
            return number.ToString();
        }
    }
}
