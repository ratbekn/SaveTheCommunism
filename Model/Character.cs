using System;
using System.Collections.Generic;
using System.Drawing;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public abstract class Character
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }
        public Vector Position { get; set; }
        public Vector Direction { get; set; }
        public Vector Speed { get; set; }
        public Vector Velocity { get; set; }

        public Character(int health, int damage, Vector position, Vector speed, Vector velocity)
        {
            IsAlive = true;
            Health = health;
            Damage = damage;
            Position = position;
            Speed = speed;
            Velocity = velocity;
        }

        public virtual void Hit(Character another)
        {
            another.TakeDamage(Damage);
        }

        private void TakeDamage(int damage)
        {
            Health -= damage;
            UpdateIAlive();
        }

        private void UpdateIAlive()
        {
            if (Health <= 0)
                IsAlive = false;
        }

        //public void UpdateState(Vector mousePosition)
        //{
        //    Speed = Speed.Rotate(mousePosition.Angle);
        //    Position += Speed;
        //    Speed += Velocity;

        //    //if (Health <= 0)
        //    //    //изменить на исчезновение character
        //    //    IsAlive = false;
        //}

        public enum Directions
        {
            Left,
            Right,
            Up,
            Down,
            None
        }

        private readonly Dictionary<Directions, Func<Vector, Size,Vector>> movements = new Dictionary<Directions, Func<Vector, Size,Vector>>
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

    }
}