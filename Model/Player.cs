using SaveTheCommunism.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SaveTheCommunism.Model
{
    public class Player : Character
    {
        public int RecruitAbility { get; set; }

        public Player(int health, int damage, Vector position, int speed, Directions initialMoveDirection)
            : base(health, damage, position, new Vector(speed, speed), initialMoveDirection)
        {

        }

        public Player(int health, int damage, int x, int y, int speed, Directions direction)
            : base(health, damage, new Vector(x, y), new Vector(speed, speed), direction)
        {

        }

        public override void Hit(Character another)
        {
            base.Hit(another);
            RecruitAbility++;
        }

        public void Shoot()
        {

        }
        
        public void Recruit(Enemy enemy)
        {
            RecruitAbility--;
        }
    }
}