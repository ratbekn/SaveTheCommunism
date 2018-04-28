using SaveTheCommunism.Utilities;

namespace SaveTheCommunism.Model
{
    public class Enemy : Character
    {
        public Enemy(int health, int damage, Vector position, Vector speed, Vector velocity) : base(health, damage, position, speed, velocity)
        {
        }
    }
}