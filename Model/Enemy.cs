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

        // поправить для адекватных параметров
        //private void GetRandomEnemy(Size squareSize)
        //{
        //    var random = new Random();
        //    Health = random.Next(10);
        //    Damage = random.Next(5);
        //    Position = new Vector(random.Next(squareSize.Width), random.Next(squareSize.Height));
        //    Speed = new Vector(random.Next(5), random.Next(5));
        //    Velocity = new Vector(random.Next(5), random.Next(5));
        //}

        public static Vector GetRandomEnemyPosition(Size squareSize)
        {
            var random = new Random();
            return new Vector(random.Next(squareSize.Width), random.Next(squareSize.Height));
        }

        public void Move(Size squareSize, Vector playerPosition)
        {
            //var random = new Random();
            //var temp = random.Next();
            //if (temp % 2 == 0)
            //    DoSmthg1(squareSize);
            //else
                DoSmthg2(squareSize, playerPosition);
        }

        private void DoSmthg2(Size squareSize, Vector playerPosition)
        {
            var dir = Directions.None;
            if (Position.X <= playerPosition.X && Position.Y < playerPosition.Y)
                dir = Directions.Right;
            if (Position.X < playerPosition.X && Position.Y >= playerPosition.Y)
                dir = Directions.Down;
            if (Position.X > playerPosition.X && Position.Y <= playerPosition.Y)
                dir = Directions.Left;
            if (Position.X >= playerPosition.X && Position.Y > playerPosition.Y)
                dir = Directions.Up;
            Move(dir, squareSize);
        }

        //private void DoSmthg1(Size squareSize)
        //{
        //    var random = new Random();
        //    var num = 30000;
        //    var ran = random.Next(num);
        //    var dir = Directions.None;
        //    if (ran < num / 4)
        //        dir = Directions.Left;
        //    if (ran >= num / 4 && ran < num / 2)
        //        dir = Directions.Down;
        //    if (ran >= num / 2 && ran < num / 2 * 3)
        //        dir = Directions.Up;
        //    if (ran >= num / 2 * 3 && ran < num)
        //        dir = Directions.Right;
        //    Move(dir, squareSize);
        //}
    }
}