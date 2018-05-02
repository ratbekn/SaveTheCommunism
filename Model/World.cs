using System;
using System.Collections.Generic;
using System.Linq;
using SaveTheCommunism.Utilities;
using System.Drawing;

namespace SaveTheCommunism.Model
{
    class World
    {
        public Size WorldSize { get; set; }
        private const int DefaultHealth = 10;
        private const int DefaultDamage = 2;
        private const int DefaultSpeed = 1;
        private const int DefaultNumberOfEnemies = 5;
        private const Directions DefaultDirection = Directions.Up;

        private const int DefaultPlayerHealth = 10;
        private const int DefaultPlayerDamage = 2;
        private const int DefaultPlayerSpeed = 2;
        private const Directions DefaultPlayerDirection = Directions.Up;

        public Player Player { get; set; }
        private Dictionary<int, Enemy> enemies;
        private Dictionary<int, Supporter> supporters;

        public int Ammo { get; set; }
        public int Score { get; set; }

        private static World instance;

        public static World GetInstance(Size worldSize) => instance ?? new World(worldSize);

        private World(Size worldSize)
        {
            WorldSize = worldSize;
            Player = new Player(DefaultPlayerHealth, DefaultPlayerDamage, WorldSize.Width / 2, WorldSize.Height / 2, DefaultPlayerSpeed, DefaultPlayerDirection);
            supporters = new Dictionary<int, Supporter>();
            enemies = new Dictionary<int, Enemy>();
            for (var i = 0; i < DefaultNumberOfEnemies; i++)
                CreateEnemy();
        }

        public void CreateEnemy()
        {
            var enemy = new Enemy(DefaultHealth, DefaultDamage, GetRandomEnemyPosition(), DefaultSpeed, DefaultDirection);
            enemies.Add(enemy.GetHashCode(), enemy);
        }

        private Vector GetRandomEnemyPosition()
        {
            var random = new Random();
            return new Vector(random.Next(WorldSize.Width), random.Next(WorldSize.Height));
        }

        public void CreateSupporter()
        {
            //добавить аргументы после реализации Supporter
            var supporter = new Supporter();
            supporters.Add(supporter.GetHashCode(), supporter);
        }

        public void RemoveEnemy(Enemy enemy) => enemies.Remove(enemy.GetHashCode());

        public void RemoveSupporter(Supporter supporter) => supporters.Remove(supporter.GetHashCode());

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
