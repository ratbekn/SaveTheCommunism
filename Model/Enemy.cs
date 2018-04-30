using System;
using System.Drawing;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        public Enemy(int health, int damage, Vector position, Vector speed, Vector velocity)
            : base(health, damage, position, speed, velocity)
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