using System.Collections.Generic;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public enum Directions
    {
        Up,
        UpRight,
        Right,
        RightDown,
        Down,
        DownLeft,
        Left,
        LeftUp,
        None
    }

    public abstract class Character
    {
        public Dictionary<Directions, Vector> Movements = new Dictionary<Directions, Vector>
        {
            { Directions.Up, new Vector (0, -1) },
            { Directions.UpRight, new Vector(1, -1) },
            { Directions.Right, new Vector(1, 0) },
            { Directions.RightDown, new Vector(1, 1) },
            { Directions.Down, new Vector(0, 1) },
            { Directions.DownLeft, new Vector(-1, 1) },
            { Directions.Left, new Vector(-1, 0) },
            { Directions.LeftUp, new Vector(-1, -1) },
            { Directions.None, new Vector(0, 0) }
        };

        public int Health { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }
        public Vector Position { get; set; }
        public Vector Direction { get; set; }
        public Vector Speed { get; set; }

        public Character(int health, int damage, Vector position, Vector speed)
        {
            IsAlive = true;
            Health = health;
            Damage = damage;
            Position = position;
            Speed = speed;
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

        public void Move(Directions direction) => Position += Speed * Movements[direction];
    }
}