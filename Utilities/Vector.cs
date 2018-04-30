using System.Drawing;
using static System.Math;

namespace SaveTheCommunism.Utilities
{
    public class Vector
    {
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public readonly double X;
        public readonly double Y;
        private double Length => Sqrt(X * X + Y * Y);
        public double Angle => Atan2(Y, X);
        public static Vector Zero = new Vector(0, 0);

        public override string ToString() => $"X: {X}, Y: {Y}";

        private bool Equals(Vector other) => X.Equals(other.X) && Y.Equals(other.Y);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public static Vector operator -(Vector a, Vector b) => new Vector(a.X - b.X, a.Y - b.Y);

        public static Vector operator *(Vector a, double k) => new Vector(a.X * k, a.Y * k);

        public static Vector operator /(Vector a, double k) => new Vector(a.X / k, a.Y / k);

        public static Vector operator *(double k, Vector a) => a * k;

        public static Vector operator *(Vector a, Vector b) => new Vector(a.X * b.X, a.Y * b.Y);

        public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);

        //public static Vector operator *(Vector a, Vector b) => new Vector(a.Y - b.Y, -(a.X - b.X));

        public Vector Normalize() => Length > 0 ? this * (1 / Length) : this;

        public Vector Rotate(double angle) => new Vector(X * Cos(angle) - Y * Sin(angle), X * Sin(angle) + Y * Cos(angle));

        public Vector BoundTo(Size size) => new Vector(Max(0, Min(size.Width, X)), Max(0, Min(size.Height, Y)));
    }
}