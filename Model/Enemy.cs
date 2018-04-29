using System;
using System.Drawing;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        // надо где-нибудь генерировать разные значения для врагов
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

        public void Move(Size squareSize)
        {
            var random = new Random();
            Directions dir;
            Enum.TryParse(random.Next(5).ToString(), out dir);
            Move(dir, squareSize);
        }
    }
}