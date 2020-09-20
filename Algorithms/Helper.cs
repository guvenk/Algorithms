using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class Helper
    {
        public static string CompressString(string str)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            char prev = str[0];
            for (int i = 1; i < str.Length; i++)
            {
                char curr = str[i];
                if (prev == curr)
                    count++;
                else
                {
                    if (count != 1)
                        sb.Append(count);
                    sb.Append(prev);
                    prev = curr;
                    count = 1;
                }
            }
            if (count != 1)
                sb.Append(count);
            sb.Append(prev);
            if (str.Length < sb.Length)
                return str;
            else
                return sb.ToString();
        }

        public static bool AreStringsEqual(string a, string b)
        {
            a = ReplaceNumbersWithDotsInString(a);
            b = ReplaceNumbersWithDotsInString(b);

            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == '.' || b[i] == '.')
                    continue;

                if (a[i] != b[i])
                    return false;
            }

            return true;
        }

        static string ReplaceNumbersWithDotsInString(string str)
        {
            string temp = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];

                if (char.IsDigit(ch))
                {
                    temp += ch;
                }
                else if (!string.IsNullOrEmpty(temp))
                {
                    int idx = str.IndexOf(temp);
                    str = str.Remove(idx, temp.Length);
                    string value = new string('.', int.Parse(temp));
                    str = str.Insert(idx, value);
                    temp = string.Empty;
                }
                if (i == str.Length - 1 && !string.IsNullOrEmpty(temp))
                {
                    int idx = str.IndexOf(temp);
                    str = str.Remove(idx, temp.Length);
                    string value = new string('.', int.Parse(temp));
                    str = str.Insert(idx, value);
                    temp = string.Empty;
                }
            }

            return str;
        }

        // USAGE
        //int[,] grid = new int[4, 8] {
        //        { 0, 1, 1, 0, 1 ,0, 0, 0},
        //        { 0, 1, 0, 1, 0 ,0, 0, 0},
        //        { 0, 0, 0, 0, 0 ,0, 0, 0},
        //        { 0, 1, 0, 0, 0 ,0, 0, 0}};
        //var result2 = MinHoursGuven(4, 8, grid);
        //Console.WriteLine(result2);
        // distance to reach the furthest "0" from "1"
        static int FindFurthestDistanceInGrid(int rows, int cols, int[,] grid)
        {
            UpdateMatrix(rows, cols, grid);
            int max = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (grid[i, j] > max)
                        max = grid[i, j];

            return max;
        }

        public static int[,] UpdateMatrix(int rows, int cols, int[,] matrix)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        queue.Enqueue((i, j));
                        matrix[i, j] = 0;
                    }
                    else
                        matrix[i, j] = int.MaxValue;
                }
            }

            int[,] direction = new int[4, 2]
            {
                { -1, 0 /* up */ },
                { 0, 1 /* right */ },
                { 1, 0 /* down */ },
                { 0, -1 } /* left */
            };

            while (queue.Count != 0)
            {
                (int Row, int Col) curr = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int row = curr.Row + direction[i, 0];
                    int col = curr.Col + direction[i, 1];

                    if (row >= 0 && row < rows && col >= 0 && col < cols
                        && matrix[row, col] > matrix[curr.Row, curr.Col] + 1)
                    {
                        matrix[row, col] = matrix[curr.Row, curr.Col] + 1;
                        queue.Enqueue((row, col));
                    }
                }
            }
            return matrix;
        }

        public static int LongestPalindromeCount(string s)
        {
            int[] arr = new int[58];
            int count = 0;
            for (int i = 0; i < s.Length; i++)
                arr[s[i] - 65]++;

            for (int i = 0; i < 58; i++)
            {
                if (arr[i] > 0)
                {
                    if (arr[i] % 2 == 0)
                        count += arr[i];
                    else
                        count += arr[i] - 1;
                }
            }

            if (count < s.Length)
                count++;
            return count;
        }

        public string MostCommonWord(string paragraph, string[] banned)
        {
            // usage
            //string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", string[] banned = ["hit"]
            var bannedHash = new HashSet<string>(banned);
            char[] splitters = new char[] { ',', ' ', '.', '!', '?', ';', '\'' };
            var words = paragraph.ToLower()
                .Split("!?',;. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(c => !bannedHash.Contains(c));

            var dict = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 0);
                }
                dict[word]++;
            }

            return dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public static string ConvertToBase7(int num)
        {
            var sb = new StringBuilder();
            char s = num < 0 ? '-' : '+';
            do
            {
                sb.Insert(0, Math.Abs(num % 7));
                num /= 7;
            } while (num != 0);
            if (s == '-') sb.Insert(0, s);
            return sb.ToString();
        }

        static string LongestPalindromicSubstr(string s)
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

        static int MaxSubArraySum(int[] a)
        {
            // Kadane's Alg
            int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        public static void MergeSortedTwoArrays(int[] nums1, int m, int[] nums2, int n)
        {
            // USAGE
            // var a = new int[] { 1, 2, 3, 0, 0, 0 };
            //var b = new int[] { 2, 5, 6 };
            //Merge(a, 3, b, 3);
            while (n + m > 0)
            {
                if (n == 0)
                    break;

                if (m != 0 && nums1[m - 1] > nums2[n - 1])
                {
                    nums1[n + m - 1] = nums1[m - 1];
                    m--;
                }
                else
                {
                    nums1[n + m - 1] = nums2[n - 1];
                    n--;
                }
            }
        }

        static void PrintDivisors(int n)
        {
            // Note that this loop runs  
            // till square root 
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    // If divisors are equal, 
                    // print only one 
                    if (n / i == i)
                        Console.Write(i + " ");

                    // Otherwise print both
                    else
                        Console.Write(i + " " + n / i + " ");
                }
            }
        }

        public static int[][] Merge_Intervals(int[][] intervals)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                var item = intervals[i];
                list.Add(new int[] { item[0], item[1] });
            }

            list.Sort((a, b) => a[0].CompareTo(b[0]));

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i][1] >= list[i + 1][0])
                {
                    list[i + 1][0] = list[i][0];
                    list[i + 1][1] = Math.Max(list[i][1], list[i + 1][1]);
                    list[i] = null;
                }
            }

            return list.Where(a => a != null).Select(a => new int[] { a[0], a[1] }).ToArray();
        }


        // Return the intersection of these two interval lists.
        public static int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            var result = new List<int[]>();
            int aptr = 0, bptr = 0;
            while (aptr < A.Length && bptr < B.Length)
            {
                int start = Math.Max(A[aptr][0], B[bptr][0]);
                int end = Math.Min(A[aptr][1], B[bptr][1]);
                if (start <= end)
                    result.Add(new int[2] { start, end });

                if (A[aptr][1] < B[bptr][1])
                    aptr++;
                else if (A[aptr][1] > B[bptr][1])
                    bptr++;
                else { aptr++; bptr++; }
            }
            return result.ToArray();
        }

        static List<int> RotationsOfNumber(int num)
        {
            List<int> list = new List<int>();
            int d1 = (int)Math.Log10(num) + 1;

            for (int i = 0; i < d1 - 1; i++)
            {
                int f = (int)Math.Pow(10, d1 - 1);
                int r = num % 10;
                int q = num / 10;
                num = r * f + q;
                list.Add(num);
            }

            return list;
        }

        bool DoOverlap(Point l1, Point r1, Point l2, Point r2)
        {
            // If one rectangle is on left side of other
            if (l1.X > r2.X || l2.X > r1.X)
                return false;

            // If one rectangle is above other
            if (l1.Y < r2.Y || l2.Y < r1.Y)
                return false;

            return true;
        }

        public static double ToRadians(double angleIn10thofaDegree) => (angleIn10thofaDegree * Math.PI) / 1800;

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public static double Median(int[] ar)
        {
            int n = ar.Length;
            double median = (ar[n / 2] + ar[(n - 1) / 2]) / 2.0;
            return median;
        }

        static bool AreParenthesisBalanced(char[] exp)
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

        static bool IsMatchingPair(char ch1, char ch2)
        {
            return (ch1 == '(' && ch2 == ')') || (ch1 == '{' && ch2 == '}') || (ch1 == '[' && ch2 == ']');
        }

        public static bool IsPrime(int n)
        {
            // Corner cases
            if (n <= 1) return false;
            if (n <= 3) return true;

            // This is checked so that we 
            // can skip middle five numbers
            // in below loop
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i += 6)
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;

            return true;
        }

        public static List<int> GetPrimes(int from, int until)
        {
            var list = new List<int>();
            for (int i = from; i <= until; i++)
                if (IsPrime(i))
                    list.Add(i);

            return list;
        }

        public static string NumToBase(long number, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (number == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(number);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new string(charArray, index + 1, BitsInLong - index - 1);
            if (number < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        // Function to Rearrange positive and negative numbers in a array
        static void RearrangePosNeg(int[] arr)
        {
            int key, j;
            for (int i = 1; i < arr.Length; i++)
            {
                key = arr[i];

                // if current element is positive
                // do nothing
                if (key > 0)
                    continue;

                /* if current element is negative,
                shift positive elements of arr[0..i-1],
                to one position to their right */
                j = i - 1;
                while (j >= 0 && arr[j] > 0)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                // Put negative element at its right position
                arr[j + 1] = key;
            }
        }

        static int[] PushZerosToEndOfArray(int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != 0)
                    arr[count++] = arr[i];

            while (count < arr.Length)
                arr[count++] = 0;

            return arr;
        }

        // gets the most occurring char from string
        public static char MaxCharInStr(string str)
        {
            int[] count = new int[256];

            for (int i = 0; i < str.Length; i++)
                count[str[i]]++;

            int max = -1; // Initialize max count
            char result = ' ';
            for (int i = 0; i < str.Length; i++)
            {
                if (max < count[str[i]])
                {
                    max = count[str[i]];
                    result = str[i];
                }
            }

            return result;
        }

        //check for a pair of numbers in A[] with sum as x
        static void GetPairs(int[] arr, int sum)
        {
            HashSet<int> s = new HashSet<int>();
            for (int i = 0; i < arr.Length; ++i)
            {
                int temp = sum - arr[i];

                // checking for condition
                if (temp >= 0 && s.Contains(temp))
                {
                    Console.WriteLine("Pair is :" + arr[i] + "," + temp);
                }
                s.Add(arr[i]);
            }
        }

        // brings negative values to left in the array
        static int SplitArray(int[] arr, int size)
        {
            int j = 0, i;
            for (i = 0; i < size; i++)
            {
                if (arr[i] <= 0)
                {
                    int temp;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    j++;
                }
            }

            //for (int k = 0; k < arr.Length; k++)
            //    Console.WriteLine(arr[k]);

            return j;
        }

        // shifts array elements to left by d
        static int[] LeftRotate(int[] a, int d)
        {
            int i, j, k, temp;
            for (i = 0; i < Gcd(d, a.Length); i++)
            {
                temp = a[i];
                j = i;
                while (true)
                {
                    k = j + d;
                    if (k >= a.Length)
                        k = k - a.Length;
                    if (k == i)
                        break;
                    a[j] = a[k];
                    j = k;
                }
                a[j] = temp;
            }
            return a;
        }

        static int GcdOfArray(int[] arr)
        {
            int result = arr[0];
            for (int i = 1; i < arr.Length; i++)
                result = Gcd(arr[i], result);

            return result;
        }

        // Least Common Multiple: int lsm = num1 * num2 / GCD(num1,num2)
        public static int Gcd(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public static long LeastCommonMultiple(int[] arr)
        {
            long lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {
                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 0)
                        return 0;
                    else if (arr[i] < 0)
                        arr[i] = arr[i] * (-1);
                    if (arr[i] == 1)
                        counter++;

                    if (arr[i] % divisor == 0)
                    {
                        divisible = true;
                        arr[i] = arr[i] / divisor;
                    }
                }

                if (divisible)
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                else
                    divisor++;

                if (counter == arr.Length)
                    return lcm_of_array_elements;
            }
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

        static long Factorial(int num)
        {
            if (num == 1) return 1;
            long res = num;
            for (int i = 1; i < num; i++)
                res *= i;
            return res;
        }

        //simple Permutation method
        public static IEnumerable<T[]> Permutations<T>(T[] values, int fromInd = 0)
        {
            if (fromInd + 1 == values.Length)
                yield return values;
            else
            {
                foreach (var v in Permutations(values, fromInd + 1))
                    yield return v;

                for (var i = fromInd + 1; i < values.Length; i++)
                {
                    Swap(values, fromInd, i);
                    foreach (var v in Permutations(values, fromInd + 1))
                        yield return v;
                    Swap(values, fromInd, i);
                }
            }
        }

        private static void Swap<T>(T[] values, int pos1, int pos2)
        {
            if (pos1 != pos2)
            {
                T tmp = values[pos1];
                values[pos1] = values[pos2];
                values[pos2] = tmp;
            }
        }

    }

    // Largest Number formed from an Array:             
    // arrange them in such a manner that they form the largest number possible 
    // usage:
    //IComparer myComparer = new MyClass();
    //Array.Sort(arr, myComparer);
    public class MyClass : IComparer
    {
        public int Compare(object x, object y)
        {
            string XY = x.ToString() + y.ToString();
            string YX = y.ToString() + x.ToString();

            // YX and XY are reversly compared
            return string.Compare(YX, XY);
        }
    }

}
