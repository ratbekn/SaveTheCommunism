using SaveTheCommunism.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SaveTheCommunism.Model
{
    public class Player : Character
    {
        public Player(int health, int damage, Vector position, Vector speed, Vector velocity)
            : base(health, damage, position, speed, velocity)
        {

        }

        //переименовать, слишком общее название
        //public int Ability { get; set; }

        //public override void Hit(Character another)
        //{
        //    base.Hit(another);
        //    Ability += 1;
        //}

        //public void Recruit(Enemy enemy)
        //{

        //}

        public List<Point> GetPathToNearestEnemy(List<Enemy> enemies, Size squareSize)
        {
            var currentPosition = Position.ToPoint();
            var enemiesPositions = enemies
                .Select(enemy => enemy.Position.ToPoint())
                .ToList();
            var pathToNextEnemy = GetPathToNearestEnemy(currentPosition, enemiesPositions, squareSize);
            return pathToNextEnemy == null ? new List<Point>() : pathToNextEnemy; 
        }

        private static List<Point> GetPathToNearestEnemy(Point initialPosition, List<Point> enemiesPositions, Size squareSize)
        {
            var visited = new Dictionary<Point, DijkstraData>();
            var track = new Dictionary<Point, DijkstraData>
            {
                {initialPosition, new DijkstraData(initialPosition, 0)}
            };

            while (track.Count != 0)
            {
                var toOpen = GetPointToOpen(track);

                visited.Add(toOpen, track[toOpen]);
                track.Remove(toOpen);

                if (enemiesPositions.Contains(toOpen))
                    return BuildPath(visited, initialPosition, toOpen);

                AddNextPointsToTrack(toOpen, track, visited, squareSize);
            }

            return null;
        }

        private static Point GetPointToOpen(Dictionary<Point, DijkstraData> track)
        {
            var toOpen = default(Point);
            var requiredEnergy = int.MaxValue;
            foreach (var point in track.Keys)
            {
                if (track[point].Weight >= requiredEnergy)
                    continue;
                toOpen = point;
                requiredEnergy = track[point].Weight;
            }

            return toOpen;
        }

        private static List<Point> BuildPath(Dictionary<Point, DijkstraData> track, Point start, Point end)
        {
            var result = new List<Point>();
            while (end != start)
            {
                result.Add(end);
                end = track[end].Previous;
            }
            result.Reverse();
            return result;
        }

        private static void AddNextPointsToTrack(
                Point toOpen,
                Dictionary<Point, DijkstraData> track,
                Dictionary<Point, DijkstraData> visited,
                Size squareSize)
        {
            foreach (var nextPoint in GetNextPoints(toOpen))
            {
                if (IsNextPointInCorrect(visited, nextPoint, squareSize))
                    continue;

                var weight = visited[toOpen].Weight + 1;

                if (!track.ContainsKey(nextPoint) || track[nextPoint].Weight > weight)
                    track[nextPoint] = new DijkstraData(toOpen, weight);
            }
        }

        private static bool IsNextPointInCorrect(Dictionary<Point, DijkstraData> visited, Point nextPoint, Size squareSize)
        {
            return visited.ContainsKey(nextPoint) || !InsideSquare(nextPoint, squareSize);
        }

        private static bool InsideSquare(Point point, Size squareSize)
        {
            return point.X >= 0 && point.Y >= 0 && point.X <= squareSize.Width && point.Y <= squareSize.Height;
        }

        private static readonly Size[] NextStepDirections = { new Size(0, -1), new Size(0, 1), new Size(-1, 0), new Size(1, 0) };

        private static IEnumerable<Point> GetNextPoints(Point point)
        {
            return NextStepDirections.Select(size => new Point(point.X + size.Width, point.Y + size.Height));
        }
    }

    class WeightedPath
    {
        public List<Point> Path { get; }
        public int Weight { get; }
        public Point First => Path.First();
        public Point Last => Path[Path.Count - 1];

        public WeightedPath(int weight)
        {
            Weight = weight;
            Path = new List<Point>();
        }
    }

    class DijkstraData
    {
        public Point Previous { get; }
        public int Weight { get; }

        public DijkstraData(Point previous, int weight)
        {
            Previous = previous;
            Weight = weight;
        }
    }
}