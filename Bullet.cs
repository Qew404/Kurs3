using System;
using System.Collections.Generic;

namespace GameKurs;

/// <summary>
/// Класс, представляющий логику пуль.
/// </summary>
public static class Bullet
{
    /// <summary>
    /// Список всех пуль на экране.
    /// </summary>
    public static List<(int x, int y)> Bullets { get; } = new List<(int, int)>();

    /// <summary>
    /// Создаёт новую пулю и добавляет её в список.
    /// </summary>
    /// <param name="x">Координата X пули.</param>
    /// <param name="y">Координата Y пули.</param>
    public static void Shoot(int x, int y)
    {
        Bullets.Add((x, y));
    }

    /// <summary>
    /// Обновляет позиции всех пуль и проверяет столкновения с врагами.
    /// </summary>
    public static void Update()
    {
        for (int i = 0; i < Bullets.Count; i++)
        {
            var (x, y) = Bullets[i];
            x += 1;

            if (x >= Constants.Width)
            {
                Bullets.RemoveAt(i--);
                continue;
            }

            Bullets[i] = (x, y);

            // Проверка попадания во врага
            for (int j = 0; j < Enemy.Enemies.Count; j++)
            {
                var (ex, ey) = Enemy.Enemies[j];
                if (x == ex && Math.Abs(y - ey) <= 1)
                {
                    Bullets.RemoveAt(i--);
                    Enemy.Enemies.RemoveAt(j);
                    Globals.Score++;
                    break;
                }
            }
        }
    }
}