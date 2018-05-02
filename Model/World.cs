using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheCommunism.Utilities;
using System.Drawing;

namespace SaveTheCommunism.Model
{
    class World
    {
        public Size WorldSize { get; set; }
        private int defaultHealth;
        private int defaultDamage;
        private int defaultSpeed;
        private int defaultNumberOfEnemies;
        private Directions defaultDirection;

        public Player Player { get; set; }
        private Dictionary<int, Enemy> enemies;
        private Dictionary<int, Supporter> supporters;

        private static World instance;
        public static World GetInstance(Size worldSize, int health, int damage, int speed, Directions direction, int numberOfEnemies)
        {
            instance = instance ?? new World(worldSize, health, damage, speed, direction, numberOfEnemies);
            return instance;
        }


        private World(Size worldSize, int health, int damage, int speed, Directions direction, int numberOfEnemies)
        {
            WorldSize = worldSize;
            defaultHealth = health;
            defaultDamage = damage;
            defaultSpeed = speed;
            defaultDirection = direction;
            defaultNumberOfEnemies = numberOfEnemies;

            player = new Player(defaultHealth, defaultDamage, WorldSize.Width / 2, WorldSize.Height / 2, defaultSpeed, defaultDirection);
            supporters = new Dictionary<int, Supporter>();
            enemies = new Dictionary<int, Enemy>();
            for (var i = 0; i < defaultNumberOfEnemies; i++)
                CreateEnemy();

        }

        public void CreateEnemy()
        {
            var enemy = new Enemy(defaultHealth, defaultDamage, GetRandomEnemyPosition(), defaultSpeed, defaultDirection);
            enemies.Add(enemy.GetHashCode(), enemy);
        }

        public Vector GetRandomEnemyPosition()
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

        public void RemoveEnemy(Enemy enemy)
        {
            enemies.Remove(enemy.GetHashCode());
        }

        public void RemoveSupporter(Supporter supporter)
        {
            supporters.Remove(supporter.GetHashCode());
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
