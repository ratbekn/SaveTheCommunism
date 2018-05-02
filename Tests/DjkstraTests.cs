using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using SaveTheCommunism.Model;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Tests
{
    [TestFixture]
    public class DjkstraTests
    {
        [Test]
        public void TestWithNoEnemy()
        {
            var player = new Player(10, 2, new Vector(10, 10), new Vector(1, 2));
            var path = player.GetPathToNearestEnemy(new List<Enemy>(), new Size(30, 30));
            Assert.Zero(path.Count);
        }

        [Test]
        public void TestWithOneEnemy()
        {
            var player = new Player(10, 2, new Vector(10, 10), new Vector(1, 2));
            var enemy = new Enemy(10, 2, new Vector(8, 10), new Vector(1, 2));
            var path = player.GetPathToNearestEnemy(new List<Enemy> { enemy }, new Size(30, 30));
            Assert.AreEqual(2, path.Count);
            Assert.AreEqual(new Point(9, 10), path[0]);
            Assert.AreEqual(new Point(8, 10), path[1]);
        }

        [Test]
        public void TestWithTwoEnemies()
        {
            var player = new Player(10, 2, new Vector(10, 10), new Vector(1, 2));
            var enemy1 = new Enemy(10, 2, new Vector(10, 9), new Vector(1, 2));
            var enemy2 = new Enemy(10, 2, new Vector(8, 10), new Vector(1, 2));
            var path = player.GetPathToNearestEnemy(new List<Enemy> { enemy1, enemy2 }, new Size(30, 30));
            Assert.AreEqual(1, path.Count);
            Assert.AreEqual(new Point(10, 9), path[0]);
        }
    }
}
