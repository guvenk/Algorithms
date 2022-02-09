using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Matrix
    {
        public static void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                    Console.Write(matrix[i][j] + " ");
                Console.WriteLine();
            }
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

        // Transpose + ReverseHorizontal = RotateRight
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

        // Transpose + ReverseVertical = RotateLeft
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

        public static int[,] RotateRight(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            var matrix = new int[cols, rows];
            for (int row = rows - 1; row >= 0; row--)
                for (int col = 0; col < cols; col++)
                    matrix[col, rows - 1 - row] = arr[row, col];

            return matrix;
        }

        public static int[,] RotateLeft(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            var matrix = new int[cols, rows];
            for (int col = cols - 1; col >= 0; col--)
                for (int row = 0; row < rows; row++)
                    matrix[cols - 1 - col, row] = arr[row, col];

            return matrix;
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
        private static int FindFurthestDistanceInGrid(int rows, int cols, int[,] grid)
        {
            UpdateMatrixBFS(rows, cols, grid);
            int max = 0;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (grid[i, j] > max)
                        max = grid[i, j];

            return max;
        }

        public static int[,] UpdateMatrixBFS(int rows, int cols, int[,] matrix)
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
    }
}
