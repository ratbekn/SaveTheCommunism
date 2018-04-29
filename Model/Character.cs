using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

        public void UpdateState(Vector mousePosition)
        {
            Speed = Speed.Rotate(mousePosition.Angle);
            Position += Speed;
            Speed += Velocity;

            //if (Health <= 0)
            //    //изменить на исчезновение character
            //    IsAlive = false;
        }

        // установить соответствие с wasd
        public enum Directions
        {
            Left,
            Right,
            Up,
            Down,
            None
        }

        // добавить ограничения, что x < square.Width, y < square.Height
        private Dictionary<Directions, Func<Vector, Vector>> movements = new Dictionary<Directions, Func<Vector, Vector>>
        {
            {Directions.Left, position => position.X > 0 ? new Vector(-3, 0) : Vector.Zero},
            {Directions.Right, position => position.X >= 0 ? new Vector(3, 0) : Vector.Zero},
            {Directions.Up, position => position.Y > 0 ? new Vector(0, -3) : Vector.Zero},
            {Directions.Down, position => position.Y >= 0 ? new Vector(0, 3) : Vector.Zero},
            {Directions.None, position => Vector.Zero}
        };

        public void Move(Directions dir)
        {
            Position += movements[dir](Position);
        }

    }
}