namespace _Root.Enemies.Cannon
{
    public interface ICannonModel
    {
        float Power {get; }
        float DistanceBetweenObjects {get; }
        float Cooldown {get; }

        void SetCooldown(float cooldown);
    }
}