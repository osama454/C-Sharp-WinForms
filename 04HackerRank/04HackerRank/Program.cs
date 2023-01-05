using System;

namespace _04HackerRank
{
    class Program
    {
        static void displayPathtoPrincess(int n, String[] grid)
        {
            int i, j, mx = 0, my = 0, px = 0, py = 0, done = 0;
            int moveX, moveY;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (grid[i][j] == 'm')
                    {
                        mx = j; my = i;
                        done++;
                    }
                    else if (grid[i][j] == 'p')
                    {
                        px = j; py = i;
                        done++;
                    }
                    if (done == 2) break;
                }
            }
            moveX = px - mx;
            moveY = py - my;
            if (moveY > 0)
            {
                for (i = 0; i < moveY; i++) { Console.WriteLine("DOWN"); }
            }
            else if (moveY < 0)
            {
                for (i = 0; i > moveY; i--) Console.WriteLine("UP");
            }
            if (moveX > 0)
            {
                for (i = 0; i < moveX; i++) Console.WriteLine("RIGHT");
            }
            else if (moveX < 0)
            {
                for (i = 0; i > moveX; i--) Console.WriteLine("LEFT");
            }
        }

        static void Main(String[] args)
        {
            int m;

            m = int.Parse(Console.ReadLine());

            String[] grid = new String[m];
            for (int i = 0; i < m; i++)
            {
                grid[i] = Console.ReadLine();
            }

            displayPathtoPrincess(m, grid);
        }
    }
}
