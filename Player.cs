using System;

namespace GameKurs;

/// <summary>
/// Класс, представляющий игрока.
/// </summary>
public static class Player
{
    /// <summary>
    /// Координата X игрока.
    /// </summary>
    public static int X { get; set; } = 5;

    /// <summary>
    /// Координата Y игрока.
    /// </summary>
    public static int Y { get; set; } = Constants.Height / 2;

    /// <summary>
    /// Перемещает игрока вверх.
    /// </summary>
    public static void MoveUp() => Y = Math.Max(0, Y - 1);

    /// <summary>
    /// Перемещает игрока вниз.
    /// </summary>
    public static void MoveDown() => Y = Math.Min(Constants.Height - 1, Y + 1);
}