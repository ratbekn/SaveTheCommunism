using System;
using NUnit.Framework;
using SaveTheCommunism.Model;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Tests
{
    class TestCharacter: Character
    {
        public TestCharacter(int health, int damage, Vector position, Vector speed)
            : base(health, damage, position, speed)
        {

        }
    }

    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void TestHit()
        {
            var character1 = new TestCharacter(10, 2, new Vector(10, 10), new Vector(1, 2));
            var character2 = new TestCharacter(10, 3, new Vector(10, 15), new Vector(1, 2));
            character1.Hit(character2);
            Assert.AreEqual(8, character2.Health);
        }

        [Test]
        public void TestHitToDeath()
        {
            var character1 = new TestCharacter(10, 2, new Vector(10, 10), new Vector(1, 2));
            var character2 = new TestCharacter(2, 3, new Vector(10, 15), new Vector(1, 2));
            character1.Hit(character2);
            Assert.AreEqual(0, character2.Health);
            Assert.IsFalse(character2.IsAlive);
        }

        [Test]
        public void TestSimpleMove()
        {
            var character = new TestCharacter(10, 2, new Vector(10, 10), new Vector(1, 2));
            character.Move(Directions.Left);
            Assert.AreEqual(character.Position.X, 9);
            Assert.AreEqual(character.Position.Y, 10);           
        }

        [Test]
        public void TestSeveralMoves()
        {
            var character = new TestCharacter(10, 2, new Vector(10, 10), new Vector(1, 1));
            for (var i = 0; i < 4; i++)
                character.Move(Directions.Right);
            //character.Move(Directions.DownLeft);
            //character.Move(Directions.Down);
            //Assert.AreEqual(character.Position.X, 14);
            //Assert.AreEqual(character.Position.Y, 10);
        }
    }
}
