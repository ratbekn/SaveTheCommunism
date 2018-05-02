using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    class Supporter : Character
    {
        public Supporter(int health, int damage, Vector position, int speed, Directions initialMoveDirection) 
            : base(health, damage, position, new Vector(speed, speed), initialMoveDirection)
        {
        }

        public Supporter(int health, int damage, int x, int y, int speed, Directions initialMoveDirection)
            : base(health, damage, new Vector(x, y), new Vector(speed, speed), initialMoveDirection)
        {
        }
    }
}
