using System;

namespace Algorithms
{
    class Solution
    {
        static void Main()
        {
            int[,] matrix = new int[,]
            {
                { 1,0,0,1 },
                { 0,0,1,1 },
                { 0,0,0,0 },
                { 1,0,1,1 },
            };

            SimpleDFS test = new SimpleDFS(4, matrix);
            var result = test.NumOfIslands();
            Console.WriteLine(result);


            Console.ReadKey();
        }
    }
}
