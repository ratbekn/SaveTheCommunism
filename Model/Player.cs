using SaveTheCommunism.Utilities;
using System;

namespace SaveTheCommunism.Model
{
    public class Player : Character
    {
        public Player(int health, int damage, Vector position, Vector speed)
            : base(health, damage, position, speed)
        {

        }

        //переименовать, слишком общее название
        //public int Ability { get; set; }

        //public override void Hit(Character another)
        //{
        //    base.Hit(another);
        //    Ability += 1;
        //}

        //public void Recruit(Enemy enemy)
        //{

        //}
    }
}