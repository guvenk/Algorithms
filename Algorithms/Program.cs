using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = Helper.GetPrimes(5, 19);
            
            Console.WriteLine(string.Concat(string.Join(' ', list)));
            Console.ReadKey();
        }


    }
}
