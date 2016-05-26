using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumbers
{
    class NumberUtils
    {
        public static bool IsSymbolInBase(byte character, int baseNumber)
        {
            return character >= 0 || character < baseNumber;
        }

        public static BigNumber RemoveZerosFromBeginningOfNumber(BigNumber number)
        {
            while (number.length > 0 && number.data[number.length - 1] == 0)
            {
                number.length--;
            }

            if (IsZero(number))
            {
                number.length = 1;
                number.data = new byte[1];
                number.sign = 1;
            }

            return number;
        }

        public static bool IsZero(BigNumber number)
        {
            return (number.length == 0 || (number.length == 1 && number.data[0] == 0));
        }
    }
}
