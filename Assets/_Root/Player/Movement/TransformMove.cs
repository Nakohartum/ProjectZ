using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Player.Movement
{
    public class TransformMove : IMove
    {
        public float Speed { get; }
        public float JumpForce { get; }
        private Transform _target;
        public TransformMove(Transform target, float speed, float jumpForce)
        {
            _target = target;
            Speed = speed;
            JumpForce = jumpForce;
        }

        public void Move(Vector2 direction, float deltaTime)
        {
            var speed = Speed * deltaTime;
            direction *= speed;
            _target.Translate(direction);
        }

        public void Jump(InputAction.CallbackContext obj)
        {
            
        }
    }
}