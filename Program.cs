using System;
using System.Collections.Generic;
using System.Threading;

namespace GameKurs;
    /// <summary>
    /// Глобальные переменные и конфигурация игры.
    /// </summary>
    internal static class Globals
    {
        /// <summary>
        /// Флаг окончания игры.
        /// </summary>
        public static bool GameOver = false;

        /// <summary>
        /// Текущий счёт игрока.
        /// </summary>
        public static int Score = 0;

        /// <summary>
        /// Задержка появления врагов.
        /// </summary>
        public static int EnemySpawnDelay = 50;

        /// <summary>
        /// Объект Random для генерации случайных чисел.
        /// </summary>
        public static Random Rand = new Random();
    }

    /// <summary>
    /// Главный класс программы.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Обрабатывает пользовательский ввод (стрелки для движения, Esc для выхода).
        /// </summary>
        static void ReadInput()
        {
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                    Player.MoveUp();
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                    Player.MoveDown();
                else if (key == ConsoleKey.Escape)
                    Environment.Exit(0);
            }
        }

        /// <summary>
        /// Главный цикл игры.
        /// </summary>
        static void Main()
        {
            Console.CursorVisible = false;

            Thread inputThread = new Thread(ReadInput);
            inputThread.IsBackground = true;
            inputThread.Start();

            while (!Globals.GameOver)
            {
                GameLogic.Update();

                Console.Clear();
                Drawer.DrawBorder();
                Drawer.DrawScore();

                Drawer.Draw(Player.X, Player.Y, Constants.PlayerSymbol);

                foreach (var (x, y) in Bullet.Bullets)
                    Drawer.Draw(x, y, Constants.BulletSymbol);

                foreach (var (x, y) in Enemy.Enemies)
                    Drawer.Draw(x, y, Constants.EnemySymbol);

                foreach (var (x, y) in Obstacle.Obstacles)
                    Drawer.Draw(x, y, Constants.ObstacleSymbol);

                Thread.Sleep(100);

                // Ускорение игры со временем
                if (Globals.EnemySpawnDelay > 15 && Globals.Score % 10 == 0)
                    Globals.EnemySpawnDelay--;
            }

            Console.SetCursorPosition(Constants.Width / 2 - 5, Constants.Height / 2);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(Constants.Width / 2 - 7, Constants.Height / 2 + 1);
            Console.WriteLine($"Ваш счёт: {Globals.Score}");
            Console.ReadKey();
        }
    }