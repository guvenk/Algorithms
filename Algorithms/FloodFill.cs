using System;

namespace Algorithms
{
    public class FloodFill
    {
        // Dimentions of paint screen 
        static readonly int M = 8;
        static readonly int N = 8;

        public static void Usage()
        {
            int[,] screen = {
                { 1, 1, 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1, 0, 0},
                { 1, 0, 0, 1, 1, 0, 1, 1},
                { 1, 2, 2, 2, 2, 0, 1, 0},
                { 1, 1, 1, 2, 2, 0, 1, 0},
                { 1, 1, 1, 2, 2, 2, 2, 0},
                { 1, 1, 1, 1, 1, 2, 1, 1},
                { 1, 1, 1, 1, 1, 2, 2, 1},
            };
            int x = 4, y = 4, newValue = 3;
            int startingValue = screen[x, y];

            FloodFillUtil(screen, x, y, startingValue, newValue);

            Console.WriteLine("Updated \n");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(screen[i, j].ToString().PadRight(3));
                Console.WriteLine("\n");
            }
        }

        static void FloodFillUtil(int[,] screen, int x, int y, int oldValue, int newValue)
        {
            // Base cases 
            if (x < 0 || x >= M ||
                y < 0 || y >= N)
                return;
            if (screen[x, y] != oldValue)
                return;

            // Replace the value at (x, y) 
            screen[x, y] = newValue;

            // Recur for up,down,left,right 
            FloodFillUtil(screen, x + 1, y, oldValue, newValue);
            FloodFillUtil(screen, x - 1, y, oldValue, newValue);
            FloodFillUtil(screen, x, y + 1, oldValue, newValue);
            FloodFillUtil(screen, x, y - 1, oldValue, newValue);
        }

    }
}
