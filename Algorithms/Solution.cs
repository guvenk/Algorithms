using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class Solution
    {
        public static void Main()
        {
            var s = new Solution();

            //FreqStack freqStack = new FreqStack();
            //freqStack.Push(5); // The stack is [5]
            //freqStack.Push(7); // The stack is [5,7]
            //freqStack.Push(5); // The stack is [5,7,5]
            //freqStack.Push(7); // The stack is [5,7,5,7]
            //freqStack.Push(4); // The stack is [5,7,5,7,4]
            //freqStack.Push(5); // The stack is [5,7,5,7,4,5]
            //var re = freqStack.Pop();   // return 5, as 5 is the most frequent. The stack becomes [5,7,5,7,4].
            //Console.WriteLine(re);
            //re = freqStack.Pop();   // return 7, as 5 and 7 is the most frequent, but 7 is closest to the top. The stack becomes [5,7,5,4].
            //Console.WriteLine(re);
            //re = freqStack.Pop();   // return 5, as 5 is the most frequent. The stack becomes [5,7,4].
            //Console.WriteLine(re);
            //re = freqStack.Pop();   // return 4, as 4, 5 and 7 is the most frequent, but 4 is closest to the top. The stack becomes [5,7].
            //Console.WriteLine(re);    

            //re = freqStack.Pop();
            //Console.WriteLine(re);

            //re = freqStack.Pop();
            //Console.WriteLine(re);
            //var root = new TreeNode(3);
            //root.left = new TreeNode(5);
            //root.left.left = new TreeNode(6);
            //root.left.right = new TreeNode(2);
            //root.left.right.left = new TreeNode(7);
            //root.left.right.right = new TreeNode(4);
            //root.right = new TreeNode(1);
            //root.right.left = new TreeNode(0);
            //root.right.right = new TreeNode(8);
            // https://assets.leetcode.com/uploads/2018/12/14/binarytree.png



            Console.ReadKey();
        }

        int rootIndex = 0;
        readonly Dictionary<int, int> map = new();
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i], i);
            }

            return CreateTree(preorder, 0, preorder.Length - 1);
        }

        private TreeNode CreateTree(int[] preorder, int left, int right)
        {
            if (left > right) return null;

            int rootValue = preorder[rootIndex++];
            var root = new TreeNode(rootValue);

            root.left = CreateTree(preorder, left, map[rootValue] - 1);
            root.right = CreateTree(preorder, map[rootValue] + 1, right);

            return root;
        }

    }


    public class FreqStack
    {
        readonly Dictionary<int, int> _freq;
        readonly Dictionary<int, Stack<int>> _group;
        int _maxFreq;

        public FreqStack()
        {
            _freq = new Dictionary<int, int>();
            _group = new Dictionary<int, Stack<int>>();
        }

        public void Push(int val)
        {
            if (!_freq.ContainsKey(val))
                _freq.Add(val, 0);

            var freq = ++_freq[val];
            _maxFreq = Math.Max(_maxFreq, freq);

            if (!_group.ContainsKey(freq))
                _group.Add(freq, new Stack<int>());

            _group[freq].Push(val);
        }

        public int Pop()
        {
            int x = _group[_maxFreq].Pop();
            _freq[x]--;

            if (_group[_maxFreq].Count == 0)
                _maxFreq--;

            return x;
        }
    }
}
