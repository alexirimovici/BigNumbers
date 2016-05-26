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
                var arrayForFirstNumber = new byte[] { 2, 4, 7, 9 };
                //var firstNumber = new BigNumber(arrayForFirstNumber);
                //var secondNumber = new BigNumber("247");
                
                var e = new BigNumber("+748329");
                var c = new BigNumber("-43");

                var b = new BigNumber("-176");
                var d = new BigNumber("88");

                var firstNumber = new BigNumber("-6999");
                var secondNumber = new BigNumber("347888");
                var res = new BigNumber("-2434868112");

                var result = firstNumber * secondNumber;


                //Console.WriteLine("{0} * {1} = {2}", b, d, b / d);

                //var res = firstNumber.Equals(secondNumber);
                Console.WriteLine(result);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }


    }
}
