using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakee
{
    class food
    {
        public int posx = 0, posy = 0;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i, k = 0, j, xpos = 0, ypos = 0;
            bool lost = false, foodclose = true, snakeshouldgrow = false, therisfood = false;
            Random randy = new Random();
            int[] x = new int[1000];
            int[] y = new int[1000];
            for (i = 1; i < 100000; i++)
            {
                if ((i % 10 == 0) && (therisfood == false))
                {
                    foodclose = true;
                    while (foodclose)
                    {
                        xpos = randy.Next(0, Console.WindowWidth - 2);
                        ypos = randy.Next(0, Console.WindowHeight - 2);
                        for (j = 0; j <= k; j++)
                        {
                            if (Math.Abs(xpos - x[j]) + Math.Abs(ypos - y[j]) < 10)
                            {
                                foodclose = true;
                                break;
                            }
                            foodclose = false;
                            therisfood = true;
                        }
                    }
                }
                if (snakeshouldgrow)
                {
                    k += 1;
                    x[k] = x[k - 1];
                    y[k] = y[k - 1];
                    snakeshouldgrow = false;
                }

                for (j = 0; j < k; j++)
                {
                    x[j] = x[j + 1];
                    y[j] = y[j + 1];
                }

                ConsoleKeyInfo kii = Console.ReadKey();
                if ((kii.Key == ConsoleKey.UpArrow) && (y[k] == 0))
                {
                    y[k] = Console.WindowHeight - 1;
                }
                if ((kii.Key == ConsoleKey.UpArrow) && (y[k] > 0))
                {
                    y[k]--;
                }
                if ((kii.Key == ConsoleKey.DownArrow) && (y[k] == Console.WindowHeight))
                {
                    y[k] = 0;
                }
                if ((kii.Key == ConsoleKey.DownArrow) && (y[k] < Console.WindowHeight))
                {
                    y[k]++;
                }
                if ((kii.Key == ConsoleKey.LeftArrow) && (x[k] == 0))
                {
                    x[k] = Console.WindowWidth - 1;
                }

                if ((kii.Key == ConsoleKey.LeftArrow) && (x[k] > 0))
                {
                    x[k]--;
                }
                if ((kii.Key == ConsoleKey.RightArrow) && (x[k] == Console.WindowWidth - 1))
                {
                    x[k] = 0;
                }
                if ((kii.Key == ConsoleKey.RightArrow) && (x[k] < Console.WindowWidth - 1))
                {
                    x[k]++;
                }
                if ((xpos == x[k]) && (ypos == y[k]) && (therisfood))
                {
                    snakeshouldgrow = true;
                    therisfood = false;

                }
                for (j = 0; j < k; j++)
                {
                    if (x[k] == x[j] && y[k] == y[j])
                    {
                        lost = true;
                        break;
                    }
                }
                if (lost == true)
                {
                    break;
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Clear();
                if (therisfood)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(xpos, ypos);
                    Console.WriteLine(" ");
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                /*
                int [,] arxy= new int [k,2];
                for(i=0; i<=k; i++)
                {
                arxy[i,0]=x[i];
                arxy[i,1]=y[i];
                } 

                */
                for (j = 0; j <= k; j++)
                {
                    Console.SetCursorPosition(x[j], y[j]);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(x[k], y[k]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");

            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("YOU LOSE");
            int score = k + 1;
            Console.SetCursorPosition(47
                , 15);
            Console.WriteLine("Snake Length: {0}", score);
            Console.ReadKey();
        }
    }
}
