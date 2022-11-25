namespace _Root.Enemies.Cannon
{
    public class CannonModel : ICannonModel
    {
        public float Power { get; private set; }
        public float DistanceBetweenObjects { get; private set; }
        public float Cooldown { get; private set; }

        public CannonModel(float power, float distanceBetweenObjects, float cooldown)
        {
            Power = power;
            DistanceBetweenObjects = distanceBetweenObjects;
            Cooldown = cooldown;
        }

        public void SetCooldown(float cooldown)
        {
            Cooldown = cooldown;
        }
    }
}