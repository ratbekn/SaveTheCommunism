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

        public static Vector GetRandomEnemyPosition(Size squareSize)
        {
            var random = new Random();
            return new Vector(random.Next(squareSize.Width), random.Next(squareSize.Height));
        }

        public void Move(Vector playerPosition)
        {
            var direction = Directions.None;

            if (Position.X < playerPosition.X && Position.Y < playerPosition.Y)
                direction = playerPosition.X - Position.X > playerPosition.Y - Position.Y
                    ? Directions.Right
                    : playerPosition.X - Position.X == playerPosition.Y - Position.Y
                        ? Directions.RightDown
                        : Directions.Down;

            if (Position.X < playerPosition.X && Position.Y >= playerPosition.Y)
                direction = playerPosition.X - Position.X > Position.Y - playerPosition.Y
                    ? Directions.Right
                    : playerPosition.X - Position.X == Position.Y - playerPosition.Y
                        ? Directions.UpRight
                        : Directions.Up;

            if (Position.X >= playerPosition.X && Position.Y < playerPosition.Y)
                direction = Position.X - playerPosition.X > playerPosition.Y - Position.Y
                    ? Directions.Left
                    : Position.X - playerPosition.X == playerPosition.Y - Position.Y
                        ? Directions.DownLeft
                        : Directions.Down;

            if (Position.X >= playerPosition.X && Position.Y >= playerPosition.Y)
                direction = Position.X - playerPosition.X > Position.Y - playerPosition.Y
                    ? Directions.Left
                    : Position.X - playerPosition.X == Position.Y - playerPosition.Y
                        ? Directions.LeftUp
                        : Directions.Up;

            Move(direction);
        }
    }
}