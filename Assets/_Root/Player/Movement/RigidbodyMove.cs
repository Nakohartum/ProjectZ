using _Root.Extensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Root.Player.Movement
{
    public class RigidbodyMove : IMove
    {
        public float Speed { get; }
        public float JumpForce { get; }
        private Rigidbody2D _rigidbody;
        private float _acceleration;
        

        public RigidbodyMove(Rigidbody2D rigidbody, float speed, float jumpForce, float acceleration)
        {
            _rigidbody = rigidbody;
            Speed = speed;
            JumpForce = jumpForce;
            _acceleration = acceleration;
        }
        
        public void Move(Vector2 direction, float deltaTime)
        {
            
            // var rigidbodyVelocity = _rigidbody.velocity;
            // if (Mathf.Abs(rigidbodyVelocity.x) >= Speed)
            // {
            //     rigidbodyVelocity = Vector3.ClampMagnitude(rigidbodyVelocity, Speed);
            //     rigidbodyVelocity.y = _rigidbody.velocity.y;
            //     _rigidbody.velocity = rigidbodyVelocity;
            // }
            // else
            // {
            //     _rigidbody.AddForce(direction * _acceleration);
            // }
            
            PhysicsHelper.ApplyForceToReachVelocity(_rigidbody, direction, deltaTime, _acceleration);
        }

        public void Jump(InputAction.CallbackContext obj)
        {
            float power = Mathf.Sqrt(JumpForce * -2 * (Physics2D.gravity.y * _rigidbody.gravityScale));
            var rigidbodyVelocity = _rigidbody.velocity;
            rigidbodyVelocity.y += power;
            _rigidbody.velocity = rigidbodyVelocity;
        }
    }
}