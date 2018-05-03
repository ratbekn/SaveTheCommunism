using System.Collections.Generic;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public enum Directions
    {
        Up,
        RightUp,
        Right,
        RightDown,
        Down,
        LeftDown,
        Left,
        LeftUp,
        None
    }

    public class Character
    {
        public Dictionary<Directions, Vector> Movements = new Dictionary<Directions, Vector>
        {
            { Directions.Up, new Vector (0, -1) },
            { Directions.RightUp, new Vector(1, -1) },
            { Directions.Right, new Vector(1, 0) },
            { Directions.RightDown, new Vector(1, 1) },
            { Directions.Down, new Vector(0, 1) },
            { Directions.LeftDown, new Vector(-1, 1) },
            { Directions.Left, new Vector(-1, 0) },
            { Directions.LeftUp, new Vector(-1, -1) },
            { Directions.None, new Vector(0, 0) }
        };

        public int Health { get; set; }
        public int Damage { get; set; }
        public Vector Position { get; set; }
        public Directions MoveDirection { get; set; }
        public Vector Speed { get; set; }
        public bool IsAlive => Health > 0;
        public bool IsMoving { get; set; }

        protected Character(int health, int damage, Vector position, Vector speed, Directions initialMoveDirection)
        {
            Health = health;
            Damage = damage;
            Position = position;
            Speed = speed;
            MoveDirection = initialMoveDirection;
            IsMoving = false;
        }

        public virtual void Hit(Character another) => another.TakeDamage(Damage);

        private void TakeDamage(int damage) => Health -= damage;

        public void Move()
        {
            if (IsMoving)
                Position += Speed * Movements[MoveDirection];
        }
    }
}