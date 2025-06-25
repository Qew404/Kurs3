using System;

namespace GameKurs;

/// <summary>
/// Класс, отвечающий за отрисовку объектов на экране.
/// </summary>
public static class Drawer
{
    /// <summary>
    /// Рисует объект на указанной позиции.
    /// </summary>
    /// <param name="x">Координата X.</param>
    /// <param name="y">Координата Y.</param>
    /// <param name="symbol">Символ для рисования.</param>
    public static void Draw(int x, int y, string symbol)
    {
        if (x >= 0 && x < Constants.Width && y >= 0 && y < Constants.Height)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
    }

    /// <summary>
    /// Рисует границы игрового поля.
    /// </summary>
    public static void DrawBorder()
    {
        for (int x = 0; x < Constants.Width; x++)
        {
            Draw(x, 0, Constants.BorderHorizontal.ToString());
            Draw(x, Constants.Height - 1, Constants.BorderHorizontal.ToString());
        }

        for (int y = 0; y < Constants.Height; y++)
        {
            Draw(0, y, Constants.BorderVertical.ToString());
            Draw(Constants.Width - 1, y, Constants.BorderVertical.ToString());
        }
    }

    /// <summary>
    /// Отображает текущий счёт игрока.
    /// </summary>
    public static void DrawScore()
    {
        Console.SetCursorPosition(1, 0);
        Console.Write($"Очки: {Globals.Score}");
    }
}