using System.Collections.Generic;

namespace UnitTests
{
    public class BalancedParanthesis
    {
        // Balanced expression with replacement
        // https://www.geeksforgeeks.org/balanced-expression-replacement/

        // Check if parantheses are balanced
        public static string IsBalanced(string word)
        {
            Stack<char> st = new Stack<char>();

            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                if (ch == '{' || ch == '(' || ch == '[')
                    st.Push(ch);
                else
                {
                    if (st.Count == 0)
                        return "NO";
                    char opening = st.Pop();
                    if (!IsMatching(opening, ch))
                        return "NO";
                }
            }
            if (st.Count > 0)
                return "NO";

            return "YES";
        }

        static bool IsMatching(char ch, char close) => ch == '{' && close == '}' || ch == '(' && close == ')' || ch == '[' && close == ']';

    }
}
