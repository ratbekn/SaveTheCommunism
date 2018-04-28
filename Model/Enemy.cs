using System;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        // надо где-нибудь генерировать разные значения для врагов
        public Enemy(int health, int damage, Vector position, Vector speed, Vector velocity) 
            : base(health, damage, position, speed, velocity)
        {
            IsAlive = true;
            Health = health;
            Damage = damage;
            Position = position;
            Speed = speed;
            Velocity = velocity;
        }

        //public Enemy()
        //{
        //    GetRandomEnemy();
        //}

        // поправить для адекватных параметров
        private void GetRandomEnemy()
        {
            var random = new Random();
            Health = random.Next(10);
            Damage = random.Next(5);
            //Position = new Vector(random.Next(square.Width, square.Height));
            Speed = new Vector(random.Next(5), random.Next(5));
            Velocity = new Vector(random.Next(5), random.Next(5));
        }
    }
}