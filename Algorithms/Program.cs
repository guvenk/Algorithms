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
            var list = Helper.NumToBase(12, 5);
            
            Console.WriteLine(list);
            Console.ReadKey();
        }

    }
}
