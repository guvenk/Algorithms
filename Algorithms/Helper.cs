using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class Helper
    {
        private static int NumOfSquares(int l, int w)
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

        private static List<int> RotationsOfNumber(int num)
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


        // Least Common Multiple: int LCM = num1 * num2 / Gcd(num1,num2);
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


        public static IEnumerable<IEnumerable<T>> GetSubSets<T>(IEnumerable<T> source)
        {
            if (!source.Any())
                return Enumerable.Repeat(Enumerable.Empty<T>(), 1);

            var element = source.Take(1);

            var haveNots = GetSubSets(source.Skip(1));
            var haves = haveNots.Select(set => element.Concat(set));

            return haves.Concat(haveNots);
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
    public class MyCustomComparer : IComparer
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
