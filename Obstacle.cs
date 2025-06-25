using System;
using System.Collections.Generic;

namespace GameKurs;

/// <summary>
/// Класс, представляющий логику препятствий.
/// </summary>
public static class Obstacle
{
    /// <summary>
    /// Список всех препятствий на экране.
    /// </summary>
    public static List<(int x, int y)> Obstacles { get; } = new List<(int, int)>();

    /// <summary>
    /// Создаёт новое препятствие и добавляет его в список.
    /// </summary>
    public static void Spawn()
    {
        int y = Globals.Rand.Next(0, Constants.Height);
        Obstacles.Add((Constants.Width - 2, y));
    }

    /// <summary>
    /// Обновляет позиции всех препятствий и проверяет столкновения с игроком.
    /// </summary>
    public static void Update()
    {
        for (int i = 0; i < Obstacles.Count; i++)
        {
            var (x, y) = Obstacles[i];
            x -= 1;

            if (x < 0)
            {
                Obstacles.RemoveAt(i--);
                continue;
            }

            Obstacles[i] = (x, y);

            if (x == Player.X && y == Player.Y)
                Globals.GameOver = true;
        }
    }
}