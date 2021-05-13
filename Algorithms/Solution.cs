using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
#nullable enable

namespace Algorithms
{
    public class Solution
    {
        public static void Main()
        {
            //var charBoard = new char[][] {
            //    new char[] { 'o', 'a', 'a', 'n' },
            //    new char[] { 'e', 't', 'a', 'e' },
            //    new char[] { 'i', 'h', 'k', 'r' },
            //    new char[] { 'i', 'f', 'l', 'v' }
            //};

            //var words = new string[] { "pea", "eat", "rain" };

            //var sol = new Solution();
            //var res = sol.FindWords(charBoard, words);
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}



            Console.ReadKey();

        }


        private static void Util(string prev, int x, int y, HashSet<(int X, int Y)> path, char[][] board, HashSet<string> words)
        {
            // hedefe ulaştıkmı
            if (words.Contains(prev))
            {
                _result.Add(prev);
                return;
            }

            // yukarı
            if (IsSafe(x, y, board) && !path.Contains((x, y - 1)))
            {
                string word = prev + board[y][x];
                path.Add((x, y));

                Util(word, x, y - 1, path, board, words);
            }
            // sağ
            // aşağı
            // sol
        }

        private static bool IsSafe(int x, int y, char[][] board)
        {
            return x >= 0 && y >= 0 && x < board[0].Length && y < board.Length;
        }

        static readonly List<string> _result = new List<string>();

        public IList<string> FindWords(char[][] board, string[] words)
        {
            var set = words.ToHashSet();

            //Util(string.Empty, board, set);



            return _result;
        }


    }
}
