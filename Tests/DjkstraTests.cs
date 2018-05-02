using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Tests
{
    [TestFixture]
    public class DjkstraTests
    {
        [Test]
        public void TestWithNoEnemy()
        {
            var path = Dijkstra.GetPathToNearestPoint(new Vector(10, 10), new List<Point>(), new Size(30, 30));
            Assert.Zero(path.Count);
        }

        [Test]
        public void TestWithOneEnemy()
        {
            var points = new List<Point> { new Point(8, 10) };
            var path = Dijkstra.GetPathToNearestPoint(new Vector(10, 10), points, new Size(30, 30));
            Assert.AreEqual(2, path.Count);
            Assert.AreEqual(new Point(9, 10), path[0]);
            Assert.AreEqual(new Point(8, 10), path[1]);
        }

        [Test]
        public void TestWithTwoEnemies()
        {
            var points = new List<Point> { new Point(10, 9), new Point(8, 10) };
            var path = Dijkstra.GetPathToNearestPoint(new Vector(10, 10), points, new Size(30, 30));
            Assert.AreEqual(1, path.Count);
            Assert.AreEqual(new Point(10, 9), path[0]);
        }
    }
}
