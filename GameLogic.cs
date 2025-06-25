namespace GameKurs;

/// <summary>
/// Класс, содержащий общую логику обновления игры.
/// </summary>
public static class GameLogic
{
    /// <summary>
    /// Обновляет состояние игры: создание новых объектов, перемещение, столкновения.
    /// </summary>
    public static void Update()
    {
        // Препятствия
        if (Globals.Rand.Next(0, 20) == 0)
            Obstacle.Spawn();

        // Враги
        if (Globals.Rand.Next(0, Globals.EnemySpawnDelay) == 0)
            Enemy.Spawn();

        // Пули (автоматическая стрельба)
        Bullet.Shoot(Player.X + 1, Player.Y);

        // Обновляем всё
        Bullet.Update();
        Enemy.Update(Player.Y);
        Obstacle.Update();
    }
}