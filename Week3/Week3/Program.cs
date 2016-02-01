using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Week3
{
    class Program
    {
        enum moveDirection { left = -1, right = 1, up = 10, down = -10 };
        enum mode { survival, arcade, survival_withLabirinth, survival_withClone };
        static moveDirection move_dir, clone_move_dir;
        static mode game_mode;
        static bool food_exist = false, game_over = false, eat = false, pause = false, clone_eat = false;
        static Snake_fragment fragment, head, clone_head, food;
        static char[,] game_ground = new char[23, 77]; //[y,x]
        static List<Snake_fragment> snake = new List<Snake_fragment>(), cloneSnake;
        static int tx = 0, ty = 0, speed = 100, choose_level, level = 1;
        static Random randomize = new Random();
        static Thread backgrnd = new Thread(backgroundGame);
        static Thread backgroundArcade = new Thread(backgroundArcadeGame);
        static Thread backgroundClone = new Thread(backgroundCloneGame);
        static ConsoleKeyInfo key_info = new ConsoleKeyInfo();
        static Int64 score = 0;

        static void snakeInit()
        {
            move_dir = moveDirection.left;

            snake = new List<Snake_fragment>();
            head = new Snake_fragment(35, 12);
            snake.Add(head);
            head = new Snake_fragment(36, 12);
            snake.Add(head);
            head = new Snake_fragment(37, 12);
            snake.Add(head);
            head = snake[0];

            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 77; j++)
                {
                    game_ground[i, j] = ' ';
                }
            }

            for (int i = 0; i < snake.Count; i++)
            {
                game_ground[snake[i].y, snake[i].x] = 'O';
                Console.SetCursorPosition(snake[i].x + 1, snake[i].y + 1);
                Console.Write('O');
            }
        }

        static void clonesnakeInit()
        {
            clone_move_dir = moveDirection.right;

            cloneSnake = new List<Snake_fragment>();
            clone_head = new Snake_fragment(59, 7);
            cloneSnake.Add(clone_head);
            clone_head = new Snake_fragment(60, 7);
            cloneSnake.Add(clone_head);
            clone_head = new Snake_fragment(61, 7);
            cloneSnake.Add(clone_head);
            clone_head = cloneSnake[0];

            for (int i = 0; i < cloneSnake.Count; i++)
            {
                game_ground[cloneSnake[i].y, cloneSnake[i].x] = '*';
                Console.SetCursorPosition(cloneSnake[i].x + 1, cloneSnake[i].y + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('*');
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void creatingFood()
        {
            tx = randomize.Next(0, 77);
            ty = randomize.Next(0, 23);
            while (game_ground[ty, tx] == 'O' || game_ground[ty, tx] == 'X')
            {
                tx = randomize.Next(0, 77);
                ty = randomize.Next(0, 23);
            }
            food = new Snake_fragment(tx, ty);
            game_ground[ty, tx] = '@';
            Console.SetCursorPosition(tx + 1, ty + 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write('@');
            Console.ForegroundColor = ConsoleColor.White;
            food_exist = true;
        }

        static void moving()
        {
            if (move_dir == moveDirection.left)
            {
                if (head.x == 0) head = new Snake_fragment(76, head.y);
                else head = new Snake_fragment(head.x - 1, head.y);
            }
            else if (move_dir == moveDirection.right)
            {
                if (head.x == 76) head = new Snake_fragment(0, head.y);
                else head = new Snake_fragment(head.x + 1, head.y);
            }
            else if (move_dir == moveDirection.up)
            {
                if (head.y == 0) head = new Snake_fragment(head.x, 22);
                else head = new Snake_fragment(head.x, head.y - 1);
            }
            else if (move_dir == moveDirection.down)
            {
                if (head.y == 22) head = new Snake_fragment(head.x, 0);
                else head = new Snake_fragment(head.x, head.y + 1);
            }

            game_ground[snake[snake.Count - 1].y, snake[snake.Count - 1].x] = ' ';
            Console.SetCursorPosition(snake[snake.Count - 1].x + 1, snake[snake.Count - 1].y + 1);
            Console.Write(' ');
            snake.RemoveAt(snake.Count - 1);
            if (game_ground[head.y, head.x] == 'X')
                game_over = true;
            else game_ground[head.y, head.x] = 'O';
            Console.SetCursorPosition(head.x + 1, head.y + 1);
            Console.Write('O');
            snake.Insert(0, head);
        }

        static void clone_moving()
        {
            if (clone_move_dir == moveDirection.left)
            {
                if (clone_head.x == 0) clone_head = new Snake_fragment(76, clone_head.y);
                else clone_head = new Snake_fragment(clone_head.x - 1, clone_head.y);
            }
            else if (clone_move_dir == moveDirection.right)
            {
                if (clone_head.x == 76) clone_head = new Snake_fragment(0, clone_head.y);
                else clone_head = new Snake_fragment(clone_head.x + 1, clone_head.y);
            }
            else if (clone_move_dir == moveDirection.up)
            {
                if (clone_head.y == 0) clone_head = new Snake_fragment(clone_head.x, 22);
                else clone_head = new Snake_fragment(clone_head.x, clone_head.y - 1);
            }
            else if (clone_move_dir == moveDirection.down)
            {
                if (clone_head.y == 22) clone_head = new Snake_fragment(clone_head.x, 0);
                else clone_head = new Snake_fragment(clone_head.x, clone_head.y + 1);
            }

            game_ground[cloneSnake[cloneSnake.Count - 1].y, cloneSnake[cloneSnake.Count - 1].x] = ' ';
            Console.SetCursorPosition(cloneSnake[cloneSnake.Count - 1].x + 1, cloneSnake[cloneSnake.Count - 1].y + 1);
            Console.Write(' ');
            cloneSnake.RemoveAt(cloneSnake.Count - 1);
            if (game_ground[clone_head.y, clone_head.x] == 'X')
                game_over = true;
            else game_ground[clone_head.y, clone_head.x] = '*';
            Console.SetCursorPosition(clone_head.x + 1, clone_head.y + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write('*');
            Console.ForegroundColor = ConsoleColor.White;
            cloneSnake.Insert(0, clone_head);
        }

        static void clone_choose_dir()
        {
            if (food_exist)
            {
                if (clone_head.x > food.x && clone_head.y > food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.left)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.up)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                    else if (clone_move_dir == moveDirection.down)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                }
                else if (clone_head.x > food.x && clone_head.y < food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {
                        clone_move_dir = moveDirection.down;
                    }
                    else if (clone_move_dir == moveDirection.left)
                    {
                        clone_move_dir = moveDirection.down;
                    }
                    else if (clone_move_dir == moveDirection.up)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                    else if (clone_move_dir == moveDirection.down)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                }
                else if (clone_head.x < food.x && clone_head.y > food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.left)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.up)
                    {
                        clone_move_dir = moveDirection.right;
                    }
                    else if (clone_move_dir == moveDirection.down)
                    {
                        clone_move_dir = moveDirection.right;
                    }
                }
                else if (clone_head.x < food.x && clone_head.y < food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {
                        clone_move_dir = moveDirection.down;
                    }
                    else if (clone_move_dir == moveDirection.left)
                    {
                        clone_move_dir = moveDirection.down;
                    }
                    else if (clone_move_dir == moveDirection.up)
                    {
                        clone_move_dir = moveDirection.right;
                    }
                    else if (clone_move_dir == moveDirection.down)
                    {
                        clone_move_dir = moveDirection.right;
                    }
                }
                else if (clone_head.x == food.x && clone_head.y > food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.left)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.up)
                    {

                    }
                    else if (clone_move_dir == moveDirection.down)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                }
                else if (clone_head.x > food.x && clone_head.y == food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.left)
                    {

                    }
                    else if (clone_move_dir == moveDirection.up)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                    else if (clone_move_dir == moveDirection.down)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                }
                else if (clone_head.x == food.x && clone_head.y < food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {
                        clone_move_dir = moveDirection.down;
                    }
                    else if (clone_move_dir == moveDirection.left)
                    {
                        clone_move_dir = moveDirection.down;
                    }
                    else if (clone_move_dir == moveDirection.up)
                    {
                        clone_move_dir = moveDirection.left;
                    }
                    else if (clone_move_dir == moveDirection.down)
                    {

                    }
                }
                else if (clone_head.x < food.x && clone_head.y == food.y)
                {
                    if (clone_move_dir == moveDirection.right)
                    {

                    }
                    else if (clone_move_dir == moveDirection.left)
                    {
                        clone_move_dir = moveDirection.up;
                    }
                    else if (clone_move_dir == moveDirection.up)
                    {
                        clone_move_dir = moveDirection.right;
                    }
                    else if (clone_move_dir == moveDirection.down)
                    {
                        clone_move_dir = moveDirection.right;
                    }
                }
            }
        }

        static void drawField()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(" --------------------"); Console.Write("--------------------");
            Console.Write("--------------------"); Console.Write("-----------------");
            Console.SetCursorPosition(0, 24);
            Console.Write(" --------------------"); Console.Write("--------------------");
            Console.Write("--------------------"); Console.Write("-----------------");
            for (int i = 1; i < 24; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('|');
                Console.SetCursorPosition(78, i);
                Console.Write('|');
            }
        }

        static void view()
        {
            for (int i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(1, i + 1);
                for (int j = 0; j < 77; j++)
                {
                    Console.Write(game_ground[i, j]);
                }
            }
        }

        static void eatFood()
        {
            if (!(food.x == snake[snake.Count - 1].x && food.y == snake[snake.Count - 1].y)) eat = true;
            else
            {
                eat = false;
                food_exist = false;
                Thread.Sleep(speed);
                //добавляем в качестве головы ещё 1 секцию
                moving();
                snake.Add(food);
                Console.SetCursorPosition(food.x + 1, food.y + 1);
                Console.Write('O');
            }
        }

        static void clone_eatFood()
        {
            if (!(food.x == cloneSnake[cloneSnake.Count - 1].x && food.y == cloneSnake[cloneSnake.Count - 1].y)) clone_eat = true;
            else
            {
                clone_eat = false;
                food_exist = false;
                Thread.Sleep(speed);
                //добавляем в качестве головы ещё 1 секцию
                clone_moving();
                cloneSnake.Add(food);
                Console.SetCursorPosition(food.x + 1, food.y + 1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('*');
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void controlGame()
        {
            while (backgrnd.IsAlive)
            {
                if (game_over) break;
                else if (backgrnd.IsAlive)
                {
                    key_info = Console.ReadKey(true);

                    if (game_over) break;
                    else if (key_info.Key == ConsoleKey.RightArrow)
                    {
                        if (move_dir != moveDirection.left)
                        {
                            if (snake[1].x == (head.x - 1) && snake[1].y == head.y) Thread.Sleep(speed);
                            move_dir = moveDirection.right;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.UpArrow)
                    {
                        if (move_dir != moveDirection.down)
                        {
                            if (snake[1].x == head.x && snake[1].y == (head.y + 1)) Thread.Sleep(speed);
                            move_dir = moveDirection.up;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.DownArrow)
                    {
                        if (move_dir != moveDirection.up)
                        {
                            if (snake[1].x == head.x && snake[1].y == (head.y - 1)) Thread.Sleep(speed);
                            move_dir = moveDirection.down;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.P) pause = true;
                    else if (key_info.Key == ConsoleKey.LeftArrow)
                    {
                        if (move_dir != moveDirection.right)
                        {
                            if (snake[1].x == (head.x + 1) && snake[1].y == head.y) Thread.Sleep(speed);
                            move_dir = moveDirection.left;
                        }
                    }
                }
            }
        }

        static void controlArcadeGame()
        {
            while (backgroundArcade.IsAlive)
            {
                if (game_over) break;
                else if (backgroundArcade.IsAlive)
                {
                    key_info = Console.ReadKey(true);

                    if (game_over) break;
                    else if (key_info.Key == ConsoleKey.RightArrow)
                    {
                        if (move_dir != moveDirection.left)
                        {
                            if (snake[1].x == (head.x + 1) && snake[1].y == head.y) Thread.Sleep(speed);
                            move_dir = moveDirection.right;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.UpArrow)
                    {
                        if (move_dir != moveDirection.down)
                        {
                            if (snake[1].x == head.x && snake[1].y == (head.y - 1)) Thread.Sleep(speed);
                            move_dir = moveDirection.up;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.DownArrow)
                    {
                        if (move_dir != moveDirection.up)
                        {
                            if (snake[1].x == head.x && snake[1].y == (head.y + 1)) Thread.Sleep(speed);
                            move_dir = moveDirection.down;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.P) pause = true;
                    else if (key_info.Key == ConsoleKey.LeftArrow)
                    {
                        if (move_dir != moveDirection.right)
                        {
                            if (snake[1].x == (head.x - 1) && snake[1].y == head.y) Thread.Sleep(speed);
                            move_dir = moveDirection.left;
                        }
                    }
                }
            }
        }

        static void controlCloneGame()
        {
            while (backgroundClone.IsAlive)
            {
                if (game_over) break;
                else if (backgroundClone.IsAlive)
                {
                    key_info = Console.ReadKey(true);

                    if (game_over) break;
                    else if (key_info.Key == ConsoleKey.RightArrow)
                    {
                        if (move_dir != moveDirection.left)
                        {
                            if (snake[1].x == (head.x - 1) && snake[1].y == head.y) Thread.Sleep(speed);
                            move_dir = moveDirection.right;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.UpArrow)
                    {
                        if (move_dir != moveDirection.down)
                        {
                            if (snake[1].x == head.x && snake[1].y == (head.y + 1)) Thread.Sleep(speed);
                            move_dir = moveDirection.up;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.DownArrow)
                    {
                        if (move_dir != moveDirection.up)
                        {
                            if (snake[1].x == head.x && snake[1].y == (head.y - 1)) Thread.Sleep(speed);
                            move_dir = moveDirection.down;
                        }
                    }
                    else if (key_info.Key == ConsoleKey.P) pause = true;
                    else if (key_info.Key == ConsoleKey.LeftArrow)
                    {
                        if (move_dir != moveDirection.right)
                        {
                            if (snake[1].x == (head.x + 1) && snake[1].y == head.y) Thread.Sleep(speed);
                            move_dir = moveDirection.left;
                        }
                    }
                }
            }
        }

        static void backgroundGame()
        {
            while (!game_over)
            {
                if (pause)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(30, 12);
                    Console.Write("GAME PAUSED");

                    key_info = Console.ReadKey(true);
                    while (key_info.Key != ConsoleKey.P)
                    {
                        key_info = Console.ReadKey(true);
                    }
                    pause = false;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(30, 12);
                    Console.Write("            ");
                }

                for (int i = 1; i < snake.Count; i++)
                {
                    if (head.x == snake[i].x && head.y == snake[i].y) game_over = true;
                }
                if (game_over) break;
                if (food_exist == false) creatingFood();
                moving();
                if (head.x == food.x && head.y == food.y)
                {
                    eat = true;
                    score += Convert.ToInt64((Convert.ToDouble(snake.Count) / 3) * 10);
                    Console.SetCursorPosition(63, 0);
                    Console.Write(score);
                }
                if (eat)
                {
                    eatFood();
                }
                Thread.Sleep(speed);
            }
        }

        static void backgroundArcadeGame()
        {
            while (!game_over)
            {
                if (pause)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(30, 12);
                    Console.Write("GAME PAUSED");

                    key_info = Console.ReadKey(true);
                    while (key_info.Key != ConsoleKey.P)
                    {
                        key_info = Console.ReadKey(true);
                    }
                    pause = false;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(30, 12);
                    Console.Write("            ");
                }

                for (int i = 1; i < snake.Count; i++)
                {
                    if (head.x == snake[i].x && head.y == snake[i].y) game_over = true;
                }
                if (game_over) break;
                if (food_exist == false) creatingFood();
                moving();
                if (head.x == food.x && head.y == food.y)
                {
                    eat = true;
                    score += Convert.ToInt64((Convert.ToDouble(snake.Count) / 3) * 10);
                    Console.SetCursorPosition(63, 0);
                    Console.Write(score);

                    if (score >= 200 && level < 2)
                    {
                        level = 2;
                        Console.Clear();
                        snakeInit();
                        drawField();
                        Console.SetCursorPosition(56, 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("SCORE: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(63, 0);
                        Console.Write(score);
                        load_level2();
                        food_exist = false;
                    }
                    else if (score >= 700 && level < 3)
                    {
                        level = 3;
                        Console.Clear();
                        snakeInit();
                        drawField();
                        Console.SetCursorPosition(56, 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("SCORE: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(63, 0);
                        Console.Write(score);
                        load_level3();
                        food_exist = false;
                    }
                    else if (score >= 1500 && level < 4)
                    {
                        level = 4;
                        Console.Clear();
                        snakeInit();
                        drawField();
                        Console.SetCursorPosition(56, 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("SCORE: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(63, 0);
                        Console.Write(score);
                        load_level4();
                        food_exist = false;
                    }
                }
                if (eat)
                {
                    eatFood();
                }
                Thread.Sleep(speed);
            }
        }

        static void backgroundCloneGame()
        {
            while (!game_over)
            {
                if (pause)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(30, 12);
                    Console.Write("GAME PAUSED");

                    key_info = Console.ReadKey(true);
                    while (key_info.Key != ConsoleKey.P)
                    {
                        key_info = Console.ReadKey(true);
                    }
                    pause = false;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(30, 12);
                    Console.Write("            ");
                }

                for (int i = 1; i < snake.Count; i++) //самосьедание
                {
                    if (head.x == snake[i].x && head.y == snake[i].y) game_over = true;
                }

                for (int i = 0; i < snake.Count; i++) //сьедание клоном
                {
                    if (snake[i].x == clone_head.x && snake[i].y == clone_head.y) game_over = true;
                }

                for (int i = 0; i < cloneSnake.Count; i++) //сьедание клона
                {
                    if (cloneSnake[i].x == head.x && cloneSnake[i].y == head.y) game_over = true;
                }

                if (game_over) break;
                if (food_exist == false) creatingFood();

                moving();
                clone_moving();
                clone_choose_dir();

                if (head.x == food.x && head.y == food.y)
                {
                    eat = true;
                    score += Convert.ToInt64((Convert.ToDouble(snake.Count) / 3) * 10);
                    Console.SetCursorPosition(63, 0);
                    Console.Write(score);
                }
                else if (clone_head.x == food.x && clone_head.y == food.y)
                    clone_eat = true;

                if (eat)
                {
                    eatFood();
                }
                else if (clone_eat)
                {
                    clone_eatFood();
                }

                Thread.Sleep(speed);
            }
        }

        static void survivalMode()
        {
            snakeInit();
            drawField();
            choose_level = randomize.Next(1, 5);
            if (choose_level == 1)
            {
                Console.SetCursorPosition(3, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("LEVEL 1");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (choose_level == 2) load_level2();
            else if (choose_level == 3) load_level3();
            else if (choose_level == 4) load_level4();

            Console.SetCursorPosition(56, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("SCORE: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(63, 0);
            Console.Write(score);

            backgrnd.Start();
            backgrnd.IsBackground = true;

            controlGame();

            Console.Clear();

            while (true)
            {
                Console.SetCursorPosition(30, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("GAME OVER");
                Console.SetCursorPosition(30, 13);
                Console.Write("YOUR SCORE: ");
                Console.Write(score);
                Thread.Sleep(250);
                Console.SetCursorPosition(30, 11);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("             ");
                Console.SetCursorPosition(30, 13);
                Console.Write("                                         ");
                Thread.Sleep(250);
            }
        }

        static void arcadeMode()
        {
            snakeInit();
            drawField();

            Console.SetCursorPosition(3, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LEVEL 1");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(56, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("SCORE: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(63, 0);
            Console.Write(score);

            backgroundArcade.Start();
            backgroundArcade.IsBackground = true;

            controlArcadeGame();

            Console.Clear();

            while (true)
            {
                Console.SetCursorPosition(30, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("GAME OVER");
                Console.SetCursorPosition(30, 13);
                Console.Write("YOUR SCORE: ");
                Console.Write(score);
                Thread.Sleep(250);
                Console.SetCursorPosition(30, 11);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("             ");
                Console.SetCursorPosition(30, 13);
                Console.Write("                                         ");
                Thread.Sleep(250);
            }
        }

        static void survival_withClone()
        {
            snakeInit();
            clonesnakeInit();
            drawField();

            Console.SetCursorPosition(3, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LEVEL 1");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(56, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("SCORE: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(63, 0);
            Console.Write(score);

            backgroundClone.Start();
            backgroundClone.IsBackground = true;

            controlCloneGame();

            Console.Clear();

            while (true)
            {
                Console.SetCursorPosition(30, 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("GAME OVER");
                Console.SetCursorPosition(30, 13);
                Console.Write("YOUR SCORE: ");
                Console.Write(score);
                Thread.Sleep(250);
                Console.SetCursorPosition(30, 11);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("             ");
                Console.SetCursorPosition(30, 13);
                Console.Write("                                         ");
                Thread.Sleep(250);
            }
        }

        static void load_level2()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < 77; i++)
            {
                Console.Write('X');
                game_ground[0, i] = 'X';
            }
            Console.SetCursorPosition(1, 23);
            for (int i = 0; i < 77; i++)
            {
                Console.Write('X');
                game_ground[22, i] = 'X';
            }
            for (int i = 2; i < 23; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write('X');
                game_ground[i - 1, 0] = 'X';
                Console.SetCursorPosition(77, i);
                Console.Write('X');
                game_ground[i - 1, 76] = 'X';
            }

            Console.SetCursorPosition(3, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LEVEL 2");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void load_level3()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < 77; i++)
            {
                Console.Write('X');
                game_ground[0, i] = 'X';
            }
            Console.SetCursorPosition(1, 23);
            for (int i = 0; i < 77; i++)
            {
                Console.Write('X');
                game_ground[22, i] = 'X';
            }

            for (int i = 7; i < 18; i++)
            {
                Console.SetCursorPosition(5, i);
                for (int j = 5; j < 27; j++)
                {
                    game_ground[i - 1, j - 1] = 'X';
                    Console.Write('X');
                }
            }

            for (int i = 4; i < 9; i++)
            {
                Console.SetCursorPosition(45, i);
                for (int j = 45; j < 60; j++)
                {
                    game_ground[i - 1, j - 1] = 'X';
                    Console.Write('X');
                }
            }

            for (int i = 16; i < 22; i++)
            {
                Console.SetCursorPosition(49, i);
                for (int j = 49; j < 64; j++)
                {
                    game_ground[i - 1, j - 1] = 'X';
                    Console.Write('X');
                }
            }

            Console.SetCursorPosition(3, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LEVEL 3");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void load_level4()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < 77; i++)
            {
                Console.Write('X');
                game_ground[0, i] = 'X';
            }
            Console.SetCursorPosition(1, 23);
            for (int i = 0; i < 77; i++)
            {
                Console.Write('X');
                game_ground[22, i] = 'X';
            }

            for (int i = 2; i < 14; i++)
            {
                Console.SetCursorPosition(4, i);
                for (int j = 4; j < 9; j++)
                {
                    game_ground[i - 1, j - 1] = 'X';
                    Console.Write('X');
                }
            }

            for (int i = 11; i < 23; i++)
            {
                Console.SetCursorPosition(13, i);
                for (int j = 13; j < 18; j++)
                {
                    game_ground[i - 1, j - 1] = 'X';
                    Console.Write('X');
                }
            }

            for (int i = 6; i < 16; i++)
            {
                Console.SetCursorPosition(45, i);
                game_ground[i - 1, 44] = 'X';
                Console.Write('X');
            }

            Console.SetCursorPosition(47, 4);
            Console.Write("XXXXXXXXXXXXXXXXXXX");
            for (int i = 0; i < 19; i++)
            {
                game_ground[3, 46 + i] = 'X';
            }

            Console.SetCursorPosition(47, 17);
            Console.Write("XXXXXXXXXXXXXXXXXXX");
            for (int i = 0; i < 19; i++)
            {
                game_ground[16, 46 + i] = 'X';
            }

            Console.SetCursorPosition(17, 8);
            Console.Write("XXXXXXXXXXXXXXXXXXX");
            for (int i = 0; i < 19; i++)
            {
                game_ground[7, 16 + i] = 'X';
            }

            for (int i = 2; i < 8; i++)
            {
                Console.SetCursorPosition(35, i);
                game_ground[i - 1, 34] = 'X';
                Console.Write('X');
            }

            Console.SetCursorPosition(3, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("LEVEL 4");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WriteLine("Choose one of game modes:");
            Console.WriteLine();
            Console.WriteLine("1) Press 1 for survival mode.");
            Console.WriteLine("2) Press 2 for arcade mode.");
            Console.WriteLine("3) Press 3 for survival mode with clone.");

            while (true)
            {
                key_info = Console.ReadKey(true);

                if (key_info.Key == ConsoleKey.D1)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Console.SetCursorPosition(0, 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("1) Press 1 for survival mode.");
                        Thread.Sleep(75);
                        Console.SetCursorPosition(0, 2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("                                ");
                        Thread.Sleep(75);
                    }
                    game_mode = mode.survival;
                    break;
                }
                else if (key_info.Key == ConsoleKey.D2)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("2) Press 2 for arcade mode.");
                        Thread.Sleep(75);
                        Console.SetCursorPosition(0, 3);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("                                ");
                        Thread.Sleep(75);
                    }
                    game_mode = mode.arcade;
                    break;
                }
                else if (key_info.Key == ConsoleKey.D3)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("4) Press 4 for survival mode with clone.");
                        Thread.Sleep(75);
                        Console.SetCursorPosition(0, 4);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("                                              ");
                        Thread.Sleep(75);
                    }
                    game_mode = mode.survival_withClone;
                    break;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.SetCursorPosition(0, 7);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Invalid input! Try again!");
                        Thread.Sleep(75);
                        Console.SetCursorPosition(0, 7);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("                           ");
                        Thread.Sleep(75);
                    }
                }
            }

            Console.Clear();

            if (game_mode == mode.survival) survivalMode();
            else if (game_mode == mode.arcade) arcadeMode();
            else if (game_mode == mode.survival_withClone) survival_withClone();


        }
    }
}