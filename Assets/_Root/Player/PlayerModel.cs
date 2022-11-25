using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public class PlayerModel : IPlayerModel
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }

        public PlayerModel(float speed, float acceleration, float jumpForce)
        {
            Speed = speed;
            Acceleration = acceleration;
            JumpForce = jumpForce;
        }

        public void AddSpeed(float speed)
        {
            Speed += speed;
        }

        public void RemoveSpeed(float speed)
        {
            Speed -= speed;
        }
    }
}