namespace Game
{
    public interface IPlayerModel
    {
        float Speed { get; }
        float Acceleration { get; }
        float JumpForce { get; }

        void AddSpeed(float speed);
        void RemoveSpeed(float speed);
    }
}