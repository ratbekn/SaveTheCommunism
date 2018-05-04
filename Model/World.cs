using System;
using System.Collections.Generic;
using System.Linq;
using SaveTheCommunism.Utilities;
using System.Drawing;

namespace SaveTheCommunism.Model
{
    internal class World
    {
        public Size WorldSize { get; set; }
        //configs
        private const int DefaultHealth = 5;
        private const int DefaultDamage = 2;
        private const int DefaultSpeed = 3;
        private const int DefaultNumberOfEnemies = 5;
        private const Directions DefaultDirection = Directions.Up;

        private const int DefaultPlayerHealth = 100;
        private const int DefaultPlayerDamage = 5;
        private const int DefaultPlayerSpeed = 4;
        private const Directions DefaultPlayerDirection = Directions.Up;

        public Player Player { get; set; }
        private readonly Dictionary<int, Enemy> enemies;
        private readonly Dictionary<int, Supporter> supporters;

        public IEnumerable<Enemy> Enemies => enemies.Values;
        public IEnumerable<Supporter> Supporters => supporters.Values;

        public int Score { get; set; }

        static readonly Random Random = new Random();

        private static World instance;

        public static World GetInstance(Size worldSize)
        {
            instance = instance ?? new World(worldSize);
            return instance;
        }

        private World(Size worldSize)
        {
            WorldSize = worldSize;
            Player = new Player(DefaultPlayerHealth, DefaultPlayerDamage, WorldSize.Width / 2,
                WorldSize.Height / 2, DefaultPlayerSpeed, DefaultPlayerDirection);

            supporters = new Dictionary<int, Supporter>();

            enemies = new Dictionary<int, Enemy>();
            var enemiesPositions = new HashSet<Vector>();
            for (var i = 0; i < DefaultNumberOfEnemies; i++)
            {
                var enemy = CreateEnemy(enemiesPositions);
                enemies.Add(enemy.GetHashCode(), enemy);
            }
        }

        public Enemy CreateEnemy(HashSet<Vector> enemiesPositions)
        {
            var currentPosition = GetRandomCharacterPosition;
            while (enemiesPositions.Contains(currentPosition))
                currentPosition = GetRandomCharacterPosition;
            enemiesPositions.Add(currentPosition);
            return new Enemy(DefaultHealth, DefaultDamage, currentPosition, DefaultSpeed, DefaultDirection);
        }

        private Vector GetRandomCharacterPosition => new Vector(Random.Next(WorldSize.Width), Random.Next(WorldSize.Height));

        public void CreateSupporter()
        {
            var supporter = new Supporter(DefaultHealth, DefaultDamage, GetRandomCharacterPosition, DefaultSpeed, DefaultDirection);
            supporters.Add(supporter.GetHashCode(), supporter);
        }

        public void RemoveCharacter(Character character)
        {
            if (character is Enemy enemy)
                enemies.Remove(enemy.GetHashCode());

            if (character is Supporter supporter)
                supporters.Remove(supporter.GetHashCode());
        }

        public void Update()
        {
            Player.Move();
            foreach (var enemy in enemies.Values)
                enemy.Move(Player.Position);
        }
    }
}
