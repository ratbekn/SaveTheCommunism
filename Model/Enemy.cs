using System;
using System.Drawing;
using SaveTheCommunism.Utilities;
using System.Collections.Generic;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        public Enemy(int health, int damage, Vector position, int speed, Directions initialMoveDirection)
            : base(health, damage, position, new Vector(speed, speed), initialMoveDirection)
        {
        }

        public Enemy(int health, int damage, int x, int y, int speed, Directions initialMoveDirection)
            : base(health, damage, new Vector(x, y), new Vector(speed, speed), initialMoveDirection)
        {

        }

        public void Move(Vector playerPosition)
        {
            var direction = Directions.None;
            var deltaX = playerPosition.X - Position.X;
            var deltaY = playerPosition.Y - Position.Y;

            if (Position.X < playerPosition.X && Position.Y < playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Right;
                else if (deltaX == deltaY)
                    MoveDirection = Directions.RightDown;
                else
                    MoveDirection = Directions.Down;
            }

            if (Position.X < playerPosition.X && Position.Y >= playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Right;
                else if (deltaX == deltaY)
                    MoveDirection = Directions.UpRight;
                else
                    MoveDirection = Directions.Up;
            }

            if (Position.X >= playerPosition.X && Position.Y < playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Left;
                else if (deltaX == deltaY)
                    MoveDirection = Directions.DownLeft;
                else
                    MoveDirection = Directions.Down;
            }

            if (Position.X >= playerPosition.X && Position.Y >= playerPosition.Y)
            {
                if (deltaX > deltaY)
                    MoveDirection = Directions.Left;
                else if (deltaX == deltaY)
                    MoveDirection = Directions.LeftUp;
                else
                    MoveDirection = Directions.Up;
            }

            Move();
        }
    }
}