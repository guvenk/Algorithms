using System;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms
{
    public class Solution
    {
        public static void Main()
        {
            var s = new Solution();

            // var edges = new int[3][];
            // edges[0] = new int[2] { 0, 1 };
            // edges[1] = new int[2] { 1, 2 };
            // edges[2] = new int[2] { 2, 0 };
            var graph = new int[4][];
            graph[0] = new int[] { 0, 1 };
            graph[1] = new int[] { 0, 2 };
            graph[2] = new int[] { 1, 3 };
            graph[3] = new int[] { 2, 3 };
            // edges[4] = new int[2] { 4, 3 };


        }

    }
}