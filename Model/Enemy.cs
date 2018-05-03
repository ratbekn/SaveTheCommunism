using SaveTheCommunism.Utilities;
using System;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        public Enemy(int health, int damage, Vector position, int speed, Directions initialMoveDirection)
            : base(health, damage, position, new Vector(speed, speed), initialMoveDirection)
        {
        }

        public Enemy(int health, int damage, int x, int y, int speed, Directions initialMoveDirection)
            : this(health, damage, new Vector(x, y), speed, initialMoveDirection)
        {
        }

        public void Move(Vector playerPosition)
        {
            var deltaX = Math.Abs(playerPosition.X - Position.X);
            var deltaY = Math.Abs(playerPosition.Y - Position.Y);

            if (Position.X < playerPosition.X && Position.Y < playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Right;
                else if (deltaX - deltaY < 1e-9)
                    MoveDirection = Directions.RightDown;
                else
                    MoveDirection = Directions.Down;
            }

            if (Position.X < playerPosition.X && Position.Y >= playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Right;
                else if (deltaX - deltaY < 1e-9)
                    MoveDirection = Directions.RightUp;
                else
                    MoveDirection = Directions.Up;
            }

            if (Position.X >= playerPosition.X && Position.Y < playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Left;
                else if (deltaX - deltaY < 1e-9)
                    MoveDirection = Directions.LeftDown;
                else
                    MoveDirection = Directions.Down;
            }

            if (Position.X >= playerPosition.X && Position.Y >= playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Left;
                else if (deltaX - deltaY < 1e-9)
                    MoveDirection = Directions.LeftUp;
                else
                    MoveDirection = Directions.Up;
            }

            if (deltaX < 1e-9 && deltaY < 1e-9)
                MoveDirection = Directions.None;

            Move();
        }
    }
}