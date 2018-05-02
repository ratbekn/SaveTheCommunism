using System;
using System.Drawing;
using SaveTheCommunism.Utilities;
using System.Collections.Generic;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        public Enemy(int health, int damage, Vector position, Vector speed)
            : base(health, damage, position, speed)
        {

        }

        //public Enemy()
        //{
        //    GetRandomEnemy();
        //}

        public static Vector GetRandomEnemyPosition(Size squareSize)
        {
            var random = new Random();
            return new Vector(random.Next(squareSize.Width), random.Next(squareSize.Height));
        }

        private readonly Dictionary<Directions, Func<Vector, Size, Vector>> movements = new Dictionary<Directions, Func<Vector, Size, Vector>>
        {
            {Directions.Left, (position, size) => position.X >= 3 ? new Vector(-3, 0) : Vector.Zero},
            {Directions.Right, (position, size) => position.X <= size.Width - 3 ? new Vector(3, 0) : Vector.Zero},
            {Directions.Up, (position, size) => position.Y >= 3 ? new Vector(0, -3) : Vector.Zero},
            {Directions.Down, (position, size) => position.Y <= size.Height - 3 ? new Vector(0, 3) : Vector.Zero},
            {Directions.None, (position, size) => Vector.Zero}
        };

        public void Move(Directions dir, Size size)
        {
            Position += movements[dir](Position, size);
        }

        public void Move(Size squareSize, Vector playerPosition)
        {
            var dir = Directions.None;
            if (Position.X < playerPosition.X && Position.Y < playerPosition.Y)
                dir = playerPosition.X - Position.X > playerPosition.Y - Position.Y ? Directions.Right : Directions.Down;

            if (Position.X < playerPosition.X && Position.Y > playerPosition.Y)
                dir = playerPosition.X - Position.X > Position.Y - playerPosition.Y ? Directions.Right : Directions.Up;

            if (Position.X > playerPosition.X && Position.Y < playerPosition.Y)
                dir = Position.X - playerPosition.X > playerPosition.Y - Position.Y ? Directions.Left : Directions.Down;

            if (Position.X > playerPosition.X && Position.Y > playerPosition.Y)
                dir = Position.X - playerPosition.X > Position.Y - playerPosition.Y ? Directions.Left : Directions.Up;

            Move(dir, squareSize);
        }
    }
}