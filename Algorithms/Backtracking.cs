using System;

namespace Algorithms
{
    public static class Backtracking
    {
        private static readonly int N = 8;
        /* xMove[] and yMove[] define 
               next move of Knight. */
        private static readonly int[] X_move = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private static readonly int[] Y_move = { 1, 2, 2, 1, -1, -2, -2, -1 };

        private static bool IsSafe(int x, int y, int[,] solution)
        {
            return (x >= 0 && x < N &&
                    y >= 0 && y < N &&
                    solution[x, y] == -1);
        }

        private static void PrintSolution(int[,] solution)
        {
            Console.WriteLine();
            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                    Console.Write((solution[x, y]).ToString().PadRight(4));
                Console.WriteLine("\n");
            }
        }

        // Night's Tour on a Chess Board.

        public static bool SolveKT()
        {
            int[,] sol = new int[8, 8];

            /* Initialization of 
            solution matrix */

            for (int x = 0; x < N; x++)
                for (int y = 0; y < N; y++)
                    sol[x, y] = -1;

            // Since the Knight is initially at the first block 
            sol[0, 0] = 0;

            /* Start from 0,0 and explore */
            if (!SolveKTUtil(0, 0, 1, sol))
            {
                Console.WriteLine("Solution does " +
                                      "not exist");
                return false;
            }
            else
                PrintSolution(sol);

            return true;
        }

        /* A recursive utility function  
        to solve Knight Tour problem */
        private static bool SolveKTUtil(int x, int y, int moveNum, int[,] solution)
        {
            int k, next_x, next_y;
            if (moveNum == N * N)
                return true;

            /* Try all next moves from  
            the current coordinate x, y */
            for (k = 0; k < 8; k++)
            {
                next_x = x + X_move[k];
                next_y = y + Y_move[k];
                if (IsSafe(next_x, next_y, solution))
                {
                    solution[next_x, next_y] = moveNum;
                    if (SolveKTUtil(next_x, next_y, moveNum + 1, solution))
                        return true;
                    else
                        // backtracking 
                        solution[next_x, next_y] = -1;
                }
            }

            return false;
        }
    }
}
