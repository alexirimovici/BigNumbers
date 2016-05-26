using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigNumbers;

namespace BigNumbersCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //byte[] a = new byte[] { 0, 0, 5 };
                //byte[] b = new byte[] { 3, 3, 6 };
                //var aBig = new BigNumber(a);
                //Console.WriteLine(aBig);
                //var bBig = new BigNumber("00057");
                //Console.WriteLine(bBig);
                
                var arrayForFirstNumber = new byte[] { 2, 4, 7, 9 };
                var firstNumber = new BigNumber(arrayForFirstNumber);
                var secondNumber = new BigNumber("247");
                var b = new BigNumber("748329");
                var e = new BigNumber("+748329");
                var c = new BigNumber("-43");
                var d = new BigNumber(0);

                var result = b + c;

                Console.WriteLine("{0} - {1} = {2}", b, e, b - e);
                Console.WriteLine("{0} + {1} = {2}", firstNumber, e, firstNumber + e);
                Console.WriteLine("{0} - {1} = {2}", b, c, b - c);
                Console.WriteLine("{0} + {1} = {2}", c, e, c + e);
                Console.WriteLine("{0} + {1} = {2}", b, d, b + d);
                Console.WriteLine("{0} + {1} = {2}", secondNumber, c, secondNumber + c);

                var res = firstNumber.Equals(secondNumber);
                Console.WriteLine(res);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }


    }
}
