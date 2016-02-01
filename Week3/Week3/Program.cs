using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey K = new ConsoleKey();
            Console.CursorVisible = false;
            int x = 0;//положение курсора x
            int y = 0;//положение курсора y
            int playersize = 0;// размер змейки
            Random random = new Random();
            int[,,] pointpos = new int[3, 3, 3];//массив для чек поинтов
            for (int i = 0; i < pointpos.GetLength(0); i++)
            {
                pointpos[i, 0, 0] = random.Next(5, 10);//заполняем массив
                pointpos[0, i, 0] = random.Next(5, 10);//заполняем массив
                pointpos[0, 0, i] = 0;
                Console.SetCursorPosition(pointpos[0, i, 0], pointpos[i, 0, 0]);
                Console.Write("@");//выводим на экран чек поинты
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("*");//выводим нашу змейку
            while (K != ConsoleKey.Escape)// пока не нажата клавиша ESC
            {
                K = Console.ReadKey().Key;
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                for (int i = 0; i < pointpos.GetLength(0); i++)
                {
                    if (x == pointpos[0, i, 0] && y == pointpos[i, 0, 0]) // если положение x и y совпадает с положением чек поинта
                    {
                        if (pointpos[0, 0, i] == 0)// если чек поинт не "съеден"(значение его 0)
                        {
                            playersize += 1; // добавляем единицу к размеру змейки
                            pointpos[0, 0, i] = 1;// помечаем чек поинт как "съеденый"(присваиваем ему значение 1)
                        }
                    }
                }
                switch (K)// для управления
                {
                    case ConsoleKey.UpArrow: // стрелка вверх
                        Console.SetCursorPosition(x, y - 1);
                        y += -1;
                        Console.Clear();
                        Clear(pointpos);
                        Console.SetCursorPosition(x, y);
                        Console.Write("*");
                        Console.SetCursorPosition(x, y - 1);
                        for (int i = 1; i < playersize + 1; i++)
                        {
                            Console.SetCursorPosition(x, y - i);
                            Console.Write("*");
                        }
                        break;

                    case ConsoleKey.DownArrow: // стрелка вниз
                        Console.SetCursorPosition(x, y + 1);
                        y += 1;
                        Console.Clear();
                        Clear(pointpos);
                        Console.SetCursorPosition(x, y);
                        Console.Write("*");
                        Console.SetCursorPosition(x, y + 1);
                        for (int i = 1; i < playersize + 1; i++)
                        {
                            Console.SetCursorPosition(x, y + i);
                            Console.Write("*");
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(x - 1, y);
                        x += -1;
                        Console.Clear();
                        Clear(pointpos);
                        Console.SetCursorPosition(x, y);
                        Console.Write("*");
                        for (int i = 1; i <= playersize; i++)
                        {
                            Console.Write("*");
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(x + 1, y);
                        x += 1;
                        Console.Clear();
                        Clear(pointpos);
                        Console.SetCursorPosition(x, y);
                        Console.Write("*");
                        for (int i = 1; i <= playersize; i++)
                        {
                            Console.Write("*");
                        }
                        break;

                }
            }

        }

        static int Clear(int[,,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[0, 0, i] == 0)
                {
                    Console.SetCursorPosition(arr[0, i, 0], arr[i, 0, 0]);
                    Console.Write("@");
                }
            }
            return 1;
        }
    }
}