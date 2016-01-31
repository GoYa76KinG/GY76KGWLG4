using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[1000];
            int[] y = new int[1000];
            int lenght = 5;

            int k = 0;
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.White;
                for (int i = 0; i < lenght; i++)
                {
                    Console.SetCursorPosition(x[i], y[i]);
                    Console.Write(" ");
                }
                for (int i = lenght - 1; i >= 1; i--)
                {
                    x[i] = x[i - 1];
                    y[i] = y[i - 1];
                }

                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow)
                {
                    if (y[0] > 0)
                        y[0]--;
                    else
                        y[0] = Console.WindowHeight - 2;
                }
                if (button.Key == ConsoleKey.DownArrow)
                {
                    if (y[0] < Console.WindowHeight - 2)
                        y[0]++;
                    else
                        y[0] = 0;
                }
                if (button.Key == ConsoleKey.LeftArrow)
                {
                    if (x[0] > 0)
                        x[0]--;
                    else
                        x[0] = Console.WindowWidth - 2;
                }
                if (button.Key == ConsoleKey.RightArrow)
                {
                    if (x[0] < Console.WindowWidth - 2)
                        x[0]++;
                    else
                        x[0] = 0;
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
            }
        }
    }
}