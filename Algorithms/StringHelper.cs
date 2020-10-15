using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    class StringHelper
    {
        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// </summary>
        public static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }

        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">Source String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        public static int GetSimilarityPercentage(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return 100;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            var result = 1.0 - (stepsToSame / (double)Math.Max(source.Length, target.Length));
            return Convert.ToInt32(result * 100);
        }

        public static bool AreParenthesisBalanced(string exp)
        {
            Stack st = new Stack();

            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
                    st.Push(exp[i]);

                if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']')
                {
                    if (st.Count < 1)
                        return false;
                    else if (!IsMatchingPair((char)st.Pop(), exp[i]))
                        return false;
                }
            }

            if (st.Count < 1)
                return true;
            else
                return false;
        }

        public static bool IsMatchingPair(char ch1, char ch2)
        {
            return (ch1 == '(' && ch2 == ')') || (ch1 == '{' && ch2 == '}') || (ch1 == '[' && ch2 == ']');
        }

        // string rotation
        static string ShiftLeft(string s, int count)
        {
            return s.Remove(0, count) + s.Substring(0, count);
        }

        static string ShiftRight(string s, int count)
        {
            return s.Remove(0, s.Length - count) + s.Substring(0, s.Length - count);
        }

        public static string LongestPalindromicSubstr(string s)
        {
            int max = 1;
            string pal = string.Empty;
            if (s.Length == 1)
                pal = s;
            for (int i = 0; i < s.Length; i++)
            {
                int j = i - 1, k = i + 1;
                int maxCurrent = 1;
                while (j > -1 && k < s.Length && s[j] == s[k])
                {
                    maxCurrent += 2;
                    j--;
                    k++;
                }
                if (maxCurrent > max)
                {
                    max = maxCurrent;
                    pal = s.Substring(j + 1, maxCurrent);
                }
                // for even counts
                j = i - 1;
                k = i;
                maxCurrent = 0;
                while (j > -1 && k < s.Length && s[j] == s[k])
                {
                    maxCurrent += 2;
                    j--;
                    k++;
                }
                if (maxCurrent > max)
                {
                    max = maxCurrent;
                    pal = s.Substring(j + 1, maxCurrent);
                }
            }

            return pal;
        }

        public static string LongestPalindrome(string s)
        {
            int maxLength = 0;
            int maxStart = 0;

            void CheckPalindrome(int left, int right)
            {
                while (left >= 0 && right < s.Length)
                {
                    if (s[left] != s[right])
                        break;

                    int length = right - left + 1;
                    if (length > maxLength)
                    {
                        maxLength = length;
                        maxStart = left;
                    }
                    left--;
                    right++;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                CheckPalindrome(i, i);
                CheckPalindrome(i, i + 1);
            }

            return s.Substring(maxStart, maxLength);
        }

        public static string FindLongestWordInDictionary(string s, List<string> dictionary)
        {
            //USAGE
            //List<string> dictionary = new List<string>() { "ale", "apple", "monkey", "plea" };

            //string res = FindLongestWord("abpcplea", dictionary);

            string result = "";

            foreach (string str in dictionary)
            {
                if (Check(s, str))
                {
                    if (result.Length < str.Length)
                        result = str;
                    else if (result.Length == str.Length)
                        if (result.CompareTo(str) > 0)
                            result = str;
                }
            }

            return result;

            bool Check(string str, string word)
            {
                int i = 0, j = 0;

                while (i < str.Length && j < word.Length)
                {
                    if (word[j] == str[i])
                    {
                        ++i;
                        ++j;
                    }
                    else
                        ++i;
                }
                if (j == word.Length)
                    return true;
                else
                    return false;
            }

        }

        public static string LongestRepeatedSubstring(string s)
        {
            var suffixes = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
                suffixes[i] = s[i..];

            Array.Sort(suffixes);

            string lrs = string.Empty;
            for (int i = 0; i < s.Length - 1; i++)
            {
                string x = LongestCommonPrefix(suffixes[i], suffixes[i + 1]);
                if (x.Length > lrs.Length)
                    lrs = x;
            }
            return lrs;
        }

        public static string LongestCommonPrefix(string s, string t)
        {
            int n = Math.Min(s.Length, t.Length);
            for (int i = 0; i < n; i++)
                if (s[i] != t[i])
                    return s[0..i];
            return s[0..n];
        }
    }
}
