using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public class Player : Character
    {
        public int RecruitAbility { get; set; }
        public bool HasGun { get; set; }

        public Player(int health, int damage, Vector position, int speed, Directions initialMoveDirection)
            : base(health, damage, position, new Vector(speed, speed), initialMoveDirection)
        {
            HasGun = false;
        }

        public Player(int health, int damage, int x, int y, int speed, Directions direction)
            : this(health, damage, new Vector(x, y), speed, direction)
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