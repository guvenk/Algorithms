using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Algorithms;

class Solution
{
    static void Main()
    {
        var oldArray = new int[3] { 1, 2, 3 };

        var newArray = SubSetsOf(oldArray).ToList();

        var t = newArray.SelectMany(a => a, (a, x) => string.Join(" ", a));

        foreach (var item in t)
        {
            Console.WriteLine(string.Concat(t));
        }

        Console.ReadKey();
    }


}
