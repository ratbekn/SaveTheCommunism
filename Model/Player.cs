namespace SaveTheCommunism.Model
{
    public class Player : Character
    {
        public int Ability { get; set; }

        public override void Hit(Character another)
        {
            base.Hit(another);
            Ability += 1;
        }

        public void Recruit(Enemy enemy)
        {
            
        }
    }
}