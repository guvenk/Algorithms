using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class ArrayCustom
    {

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

        //check for a pair of numbers in A[] with sum equal to x
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
            for (i = 0; i < Helper.Gcd(d, a.Length); i++)
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
                result = Helper.Gcd(arr[i], result);

            return result;
        }

        public static long LeastCommonMultiple(int[] arr)
        {
            long lcm = 1;
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
                    lcm *= divisor;
                else
                    divisor++;

                if (counter == arr.Length)
                    return lcm;
            }
        }

        public static double MedianOfArray(int[] ar)
        {
            int n = ar.Length;
            double median = (ar[n / 2] + ar[(n - 1) / 2]) / 2.0;
            return median;
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


    }
}
