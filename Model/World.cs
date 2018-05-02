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

        public World(Size worldSize)
        {
            WorldSize = worldSize;
            player = new Player(100, 5, WorldSize.Width / 2, WorldSize.Height / 2, 5, Directions.Up);
        }

        public void Update()
        {
            
        }

        public Enemy CreateEnemy()
        {
            throw new NotImplementedException();
        }

        public Vector GetRandomEnemyPosition()
        {
            var random = new Random();
            return new Vector(random.Next(WorldSize.Width), random.Next(WorldSize.Height));
        }
    }
}
