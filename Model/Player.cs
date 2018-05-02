using SaveTheCommunism.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SaveTheCommunism.Model
{
    public class Player : Character
    {
        public Player(int health, int damage, Vector position, Vector speed)
            : base(health, damage, position, speed)
        {
        }

        public int RecruitAbility { get; private set; }

        public override void Hit(Character another)
        {
            base.Hit(another);
            RecruitAbility++;
        }

        //костыль
        public void Recruit(Enemy enemy)
        {
            RecruitAbility--;
        }

        public void Shoot(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}