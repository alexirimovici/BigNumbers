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
                byte[] a = new byte[] { 0, 0, 5 };
                byte[] b = new byte[] { 3, 3, 6 };
                var aBig = new BigNumber(a);
                Console.WriteLine(aBig);
                var bBig = new BigNumber("00057");
                Console.WriteLine(bBig);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
