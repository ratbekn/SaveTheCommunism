using SaveTheCommunism.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SaveTheCommunism.Model
{
    public class Player : Character
    {
        public Player(int health, int damage, Vector position, Vector speed, Directions initialDirection)
            : base(health, damage, position, speed, initialDirection)
        {
        }

        public int RecruitAbility { get; set; }

        public override void Hit(Character another)
        {
            base.Hit(another);
            RecruitAbility += 1;
        }

        public void Recruit(Enemy enemy)
        {

        }
    }
}