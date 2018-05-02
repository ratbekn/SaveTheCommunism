using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace SaveTheCommunism.Utilities
{
    internal class Dijkstra
    {
        public static List<Point> GetPathToNearestPoint(Vector position, List<Point> points, Size squareSize)
        {
            var currentPosition = position.ToPoint();
            var currentPoints = points.ToList();
            var pathToNearestPoint = GetPathToNearestPoint(currentPosition, currentPoints, squareSize);
            return pathToNearestPoint ?? new List<Point>();
        }

        private static List<Point> GetPathToNearestPoint(Point initialPosition, List<Point> points, Size squareSize)
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

                if (points.Contains(toOpen))
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

    internal class WeightedPath
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

    internal class DijkstraData
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
