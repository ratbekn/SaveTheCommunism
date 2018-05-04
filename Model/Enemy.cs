using SaveTheCommunism.Utilities;
using System;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        public Enemy(int health, int damage, Vector position, int speed, Directions initialMoveDirection)
            : base(health, damage, position, new Vector(speed, speed), initialMoveDirection)
        {
            IsMoving = true;
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
                SetMoveDirection(deltaX, deltaY, Directions.Right, Directions.RightDown, Directions.Down);

            if (Position.X < playerPosition.X && Position.Y >= playerPosition.Y)
                SetMoveDirection(deltaX, deltaY, Directions.Right, Directions.RightUp, Directions.Up);

            if (Position.X >= playerPosition.X && Position.Y < playerPosition.Y)
                SetMoveDirection(deltaX, deltaY, Directions.Left, Directions.LeftDown, Directions.Down);

            if (Position.X >= playerPosition.X && Position.Y >= playerPosition.Y)
                SetMoveDirection(deltaX, deltaY, Directions.Left, Directions.LeftUp, Directions.Up);

            if (deltaX < 1e-9 && deltaY < 1e-9)
                MoveDirection = Directions.None;

            Move();
        }

        //rename
        private void SetMoveDirection(double deltaX, double deltaY, Directions dir1, Directions dir2, Directions dir3)
        {
            if (deltaX > deltaY)
                MoveDirection = dir1;
            else if (deltaX - deltaY < 1e-9)
                MoveDirection = dir2;
            else
                MoveDirection = dir3;
        }
    }
}