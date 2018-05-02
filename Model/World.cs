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
        public Player player { get; set; }

        //TEMP VALUES
        //FIX
        private int defaultHealth = 10;
        private int defaultDamage = 2;
        private int defaultSpeed = 3;
        private int defaultNumberOfEnemies = 5;
        public Dictionary<int, Enemy> enemies;
        public Dictionary<int, Supporter> supporters;

        public World(Size worldSize)
        {
            WorldSize = worldSize;
            player = new Player(defaultHealth, defaultDamage, WorldSize.Width / 2, WorldSize.Height / 2, defaultSpeed, Directions.Up);
            enemies = new Dictionary<int, Enemy>();

            for (var i = 0; i < defaultNumberOfEnemies; i++)
                CreateEnemy();

            supporters = new Dictionary<int, Supporter>();
        }

        public void CreateEnemy()
        {
            //дописать
            enemies.Add(0, new Enemy(defaultHealth, defaultDamage, GetRandomEnemyPosition(), defaultSpeed));
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
