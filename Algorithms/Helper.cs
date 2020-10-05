using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public partial class Helper
    {
        static int NumOfSquares(int l, int w)
        {
            int squareSide = Gcd(l, w);
            return (l * w) / (squareSide * squareSide);
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


        static int MaxSubArraySum(int[] a)
        {
            // Kadane's Alg
            int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here += a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        static List<int> GetDivisors(int n)
        {
            var list = new List<int>();

            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    // If divisors are equal, get one 
                    if (n / i == i)
                        list.Add(i);
                    // Otherwise  both
                    else
                        list.AddRange(new int[] { i, n / i });
                }
            }
            return list;
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

        public static double ToRadians(double angleIn10thofaDegree) => (angleIn10thofaDegree * Math.PI) / 1800;

        public static double MedianOfArray(int[] ar)
        {
            int n = ar.Length;
            double median = (ar[n / 2] + ar[(n - 1) / 2]) / 2.0;
            return median;
        }

        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;

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

        public static string NumToBase(long number, int toBase)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (toBase < 2 || toBase > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (number == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(number);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % toBase);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / toBase;
            }

            string result = new string(charArray, index + 1, BitsInLong - index - 1);
            if (number < 0)
            {
                result = "-" + result;
            }

            return result;
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

        // Least Common Multiple: int lsm = num1 * num2 / Gcd(num1,num2);
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


        //Simple Permutation method
        public static IEnumerable<T[]> Permutations<T>(T[] values, int fromInd = 0)
        {
            var list = new List<T[]>();

            if (fromInd + 1 == values.Length)
                list.Add(values);
            else
            {
                foreach (var v in Permutations(values, fromInd + 1))
                    list.Add(v);

                for (var i = fromInd + 1; i < values.Length; i++)
                {
                    Swap(values, fromInd, i);
                    foreach (var v in Permutations(values, fromInd + 1))
                        list.Add(v);
                    Swap(values, fromInd, i);
                }
            }

            return list;
        }

        public static void Swap<T>(T[] values, int pos1, int pos2)
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
