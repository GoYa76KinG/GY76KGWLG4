using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW3LSNG4
{
    public class Game
    {
        public static Food food = new Food();
        public static Snake snake = new Snake();
        public static Wall wall = new Wall();
        public bool GameOver = false;

        public Game()
        {
            Init();
            Play();
        }

        public void Init()
        {
            food.SetNewPosition();
            wall.LoadLevel(1);

        }

        public void Play()
        {
            while (!GameOver)
            {
                Draw();
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow && snake.body[0].y != 1)
                    snake.move(0, -1);

                if (button.Key == ConsoleKey.DownArrow && snake.body[0].y != 27)
                    snake.move(0, 1);

                if (button.Key == ConsoleKey.LeftArrow && snake.body[0].x != 1)
                    snake.move(-1, 0);

                if (button.Key == ConsoleKey.RightArrow && snake.body[0].x != 118)
                    snake.move(1, 0);

                if (button.Key == ConsoleKey.F5)
                    wall.LoadLevel(2);
                if (button.Key == ConsoleKey.F2)
                    Save();
                if (button.Key == ConsoleKey.F3)
                    Resume();
                GameOver = snake.CollistionWithWall();
            }
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("GAME OVER!");
            Console.ReadKey();
        }
        public void Draw()
        {
            Console.Clear();
            food.Draw();
            snake.Draw();
            wall.Draw();
        }
        public void Save()
        {
            snake.Save();
            food.Save();
            wall.Save();
        }
        public void Resume()
        {
            snake.Resume();
            food.Resume();
            wall.Resume();
        }

    }
}
