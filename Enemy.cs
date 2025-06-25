using System;
using System.Collections.Generic;

namespace GameKurs;

/// <summary>
/// Класс, представляющий логику врагов.
/// </summary>
public static class Enemy
{
    /// <summary>
    /// Список всех врагов на экране.
    /// </summary>
    public static List<(int x, int y)> Enemies { get; } = new List<(int, int)>();

    /// <summary>
    /// Создаёт нового врага и добавляет его в список.
    /// </summary>
    public static void Spawn()
    {
        int y = Globals.Rand.Next(1, Constants.Height - 1);
        Enemies.Add((Constants.Width - 2, y)); // появляются справа
    }

    /// <summary>
    /// Обновляет позиции всех врагов и проверяет столкновения с игроком.
    /// </summary>
    /// <param name="playerY">Текущая координата Y игрока.</param>
    public static void Update(int playerY)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            var (x, y) = Enemies[i];

            if (y < playerY)
                y++;
            else if (y > playerY)
                y--;

            x -= 1;

            if (x < 0)
            {
                Enemies.RemoveAt(i--);
            }
            else
            {
                Enemies[i] = (x, y);

                if (x == Player.X && y == Player.Y)
                    Globals.GameOver = true;
            }
        }
    }
}