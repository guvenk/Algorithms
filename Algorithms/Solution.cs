using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

            Trie obj = new Trie();
            obj.Insert("word");

            Console.ReadKey();

        }

        public class TrieNode
        {
            public TrieNode[] Links { get; set; } = new TrieNode[26];
            public bool IsEnd { get; set; }
        }

        public class Trie
        {
            private readonly TrieNode _root;

            public Trie() => _root = new TrieNode();

            public void Insert(string word)
            {
                TrieNode node = _root;
                for (int i = 0; i < word.Length; i++)
                {
                    char ch = word[i];
                    var temp = node.Links[ch - 'a'];
                    if (temp is null)
                        node.Links[ch - 'a'] = new TrieNode();

                    node = node.Links[ch - 'a'];
                }
                node.IsEnd = true;
            }

            public bool Search(string word)
            {
                var node = StartsWith(word);
                return node != null && node.IsEnd;
            }

            public TrieNode StartsWith(string prefix)
            {
                TrieNode node = _root;
                for (int i = 0; i < prefix.Length; i++)
                {
                    char ch = prefix[i];
                    var temp = node.Links[ch - 'a'];
                    if (temp is null)
                        return null;
                    else
                        node = temp;
                }

                return node;
            }
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
