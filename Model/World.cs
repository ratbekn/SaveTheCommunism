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

        //TEMP VALUES
        //FIX
        private int defaultHealth = 10;
        private int defaultDamage = 2;
        private Vector defaultSpeed = new Vector(1, 1);
        private int defaultNumberOfEnemies = 5;
        private Directions defaultDirection = Directions.None;
        

        private Player player;
        private Dictionary<int, Enemy> enemies;
        private Dictionary<int, Supporter> supporters;

        public World(Size worldSize)
        {
            WorldSize = worldSize;
            player = new Player(defaultHealth, defaultDamage, new Vector(worldSize.Width / 2, worldSize.Height / 2), defaultSpeed, defaultDirection);
            enemies = new Dictionary<int, Enemy>();
            for (var i = 0; i < defaultNumberOfEnemies; i++)
                CreateEnemy();
            supporters = new Dictionary<int, Supporter>();
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

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
