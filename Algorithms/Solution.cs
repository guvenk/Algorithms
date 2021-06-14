using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Solution
    {
        public static void Main()
        {
            var s = new Solution();

            var str = s.MinRemoveToMakeValid("())()(((");

            Console.WriteLine(str);
            Console.WriteLine("finished");
        }

        public string MinRemoveToMakeValid(string s)
        {
            int c = 0;
            var sb = new StringBuilder();
            foreach (var ch in s)
            {
                if (ch == '(')
                {
                    c++;
                    sb.Append('(');
                }
                else if (ch == ')')
                {
                    if (c == 0)
                        continue;
                    c--;
                    sb.Append(')');
                }
                else
                    sb.Append(ch);
            }

            for (int i = 0; i < c; i++)
            {
                var word = sb.ToString();
                int idx = word.LastIndexOf('(');
                sb.Remove(idx, 1);
            }

            return sb.ToString();
        }
    }
}