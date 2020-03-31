using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Algorithms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var list = new List<List<int>>
            //{
            //    new List<int>() { 0, 1 },
            //    new List<int>() { 0, 2 },
            //    new List<int>() { 1, 3 },
            //    new List<int>() { 2, 3 },
            //    new List<int>() { 2, 5 },
            //    new List<int>() { 5, 6 },
            //    new List<int>() { 3, 4 }
            //};

            var list = new List<List<int>>
            {
                new List<int>() { 1, 2 },
                new List<int>() { 1, 3 },
                new List<int>() { 2, 4 },
                new List<int>() { 3, 4 },
                new List<int>() { 3, 6 },
                new List<int>() { 6, 7 },
                new List<int>() { 4, 5 }
            };

            Solve(list);
            Console.ReadKey();
        }

        public static void Solve(List<List<int>> links)
        {
            FindBridgeNodes graph = new FindBridgeNodes(links[0][0]);

            foreach (var link in links)
                graph.AddEdge(link[0], link[1]);

            List<int> solution = new List<int>();
            for (int i = 0; i < links.Count; i++)
            {
                var linkPair = links[i];
                if (graph.IsBridge(linkPair[0], linkPair[1]))
                    solution.Add(linkPair[0]);
            }

            foreach (var item in solution)
                Console.WriteLine(item);
        }
    }
}
