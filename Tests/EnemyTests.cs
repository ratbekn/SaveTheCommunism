using NUnit.Framework;
using SaveTheCommunism.Model;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Tests
{
    [TestFixture]
    public class EnemyTests
    {
        [Test]
        public void TestSimpleMoveRight()
        {
            var enemy = new Enemy(10, 2, new Vector(8, 10), 1, Directions.Up);
            var player = new Player(10, 2, new Vector(10, 10), 1, Directions.Up);
            enemy.Move(player.Position);

            Assert.AreEqual(9, enemy.Position.X);
            Assert.AreEqual(10, enemy.Position.Y);
        }

        [Test]
        public void TestSimpleMoveLeft()
        {
            var enemy = new Enemy(10, 2, new Vector(12, 10), 1, Directions.Up);
            var player = new Player(10, 2, new Vector(10, 10), 1, Directions.Up);
            enemy.Move(player.Position);

            Assert.AreEqual(11, enemy.Position.X);
            Assert.AreEqual(10, enemy.Position.Y);
        }

        [Test]
        public void TestSimpleMoveUp()
        {
            var enemy = new Enemy(10, 2, new Vector(10, 12), 1, Directions.Up);
            var player = new Player(10, 2, new Vector(10, 10), 1, Directions.Up);
            enemy.Move(player.Position);

            Assert.AreEqual(10, enemy.Position.X);
            Assert.AreEqual(11, enemy.Position.Y);
        }

        [Test]
        public void TestSimpleMoveDown()
        {
            var enemy = new Enemy(10, 2, new Vector(10, 8), 1, Directions.Up);
            var player = new Player(10, 2, new Vector(10, 10), 1, Directions.Up);
            enemy.Move(player.Position);

            Assert.AreEqual(10, enemy.Position.X);
            Assert.AreEqual(9, enemy.Position.Y);
        }

        [Test]
        public void TestDiagonalMoves()
        {
            var enemy = new Enemy(10, 2, new Vector(7, 6), 1, Directions.Up);
            var player = new Player(10, 2, new Vector(10, 10), 1, Directions.Up);

            enemy.Move(player.Position);
            Assert.AreEqual(7, enemy.Position.X);
            Assert.AreEqual(7, enemy.Position.Y);

            enemy.Move(player.Position);
            Assert.AreEqual(8, enemy.Position.X);
            Assert.AreEqual(8, enemy.Position.Y);

            enemy.Move(player.Position);
            Assert.AreEqual(9, enemy.Position.X);
            Assert.AreEqual(9, enemy.Position.Y);
        }

        [Test]
        public void TestSeveralMoves()
        {
            var enemy = new Enemy(10, 2, new Vector(34, 56), 1, Directions.Up);
            var player = new Player(10, 2, new Vector(10, 10), 1, Directions.Up);

            enemy.Move(player.Position);
            Assert.AreEqual(34, enemy.Position.X);
            Assert.AreEqual(55, enemy.Position.Y);

            enemy.Move(player.Position);
            Assert.AreEqual(34, enemy.Position.X);
            Assert.AreEqual(54, enemy.Position.Y);
        }
    }
}