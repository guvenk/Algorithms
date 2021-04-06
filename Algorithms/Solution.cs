using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class Solution
    {

        public static void Main()
        {
            //var arr = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //var res = Trap(arr);

            //Console.WriteLine(res);

            var input = new int[][] {
               new int[] { 1, 2, 3 },
               new int[] { 4, 5, 6 },
               new int[] { 7, 8, 9 }
            };
            Rotate(input);


            //SetZeroes(input);
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                    Console.Write(input[i][j] + " ");
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static void SetZeroes(int[][] matrix)
        {
            bool isCol = false;
            int R = matrix.Length;
            int C = matrix[0].Length;

            for (int i = 0; i < R; i++)
            {
                if (matrix[i][0] == 0)
                    isCol = true;

                for (int j = 1; j < C; j++)
                {
                    // If an element is zero, we set the first element of the corresponding row and column to 0
                    if (matrix[i][j] == 0)
                    {
                        matrix[0][j] = 0;
                        matrix[i][0] = 0;
                    }
                }
            }

            // Iterate over the array once again and using the first row and first column, update the elements.
            for (int i = 1; i < R; i++)
                for (int j = 1; j < C; j++)
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                        matrix[i][j] = 0;

            // See if the first row needs to be set to zero as well
            if (matrix[0][0] == 0)
                for (int j = 0; j < C; j++)
                    matrix[0][j] = 0;

            // See if the first column needs to be set to zero as well
            if (isCol)
                for (int i = 0; i < R; i++)
                    matrix[i][0] = 0;
        }


        public static int Trap(int[] height)
        {
            int totalRain = 0;
            int size = height.Length;
            int[] leftMax = new int[size];
            int[] rightMax = new int[size];

            for (int i = 1; i < size; i++)
                leftMax[i] = Math.Max(leftMax[i - 1], height[i - 1]);

            for (int i = size - 2; i >= 0; i--)
                rightMax[i] = Math.Max(rightMax[i + 1], height[i + 1]);

            for (int i = 1; i < size - 1; i++)
            {
                int val = Math.Min(leftMax[i], rightMax[i]) - height[i];
                totalRain += val > 0 ? val : 0;
            }

            return totalRain;
        }

        public static int[][] Rotate(int[][] matrix)
        {
            Transpose(matrix);
            ReverseHorizontal(matrix);

            return matrix;
        }

        public static void Transpose(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                for (int j = i; j < matrix[i].Length; j++)
                {
                    int tmp = matrix[j][i];
                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = tmp;
                }
        }

        public static void ReverseHorizontal(int[][] arr)
        {
            int row = arr.Length;
            int col = arr[0].Length;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col / 2; j++)
                {
                    int tmp = arr[i][j];
                    arr[i][j] = arr[i][col - j - 1];
                    arr[i][col - j - 1] = tmp;
                }
            }
        }

        public static void ReverseVertical(int[][] arr)
        {
            int row = arr.Length;
            int col = arr[0].Length;

            for (int i = 0; i < row / 2; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int tmp = arr[i][j];
                    arr[i][j] = arr[row - i - 1][j];
                    arr[row - i - 1][j] = tmp;
                }
            }
        }

    }
}
